#if ANDROID
using Android.Content;
using Android.Locations;
using CommunityToolkit.Mvvm.Messaging;

#endif
using M.A.G.U.S.Assistant.Contexts;
using M.A.G.U.S.Assistant.Exceptions;
using M.A.G.U.S.Assistant.Interfaces.Bluetooth;
using M.A.G.U.S.Assistant.Messages;
using M.A.G.U.S.Assistant.Models.Bluetooth;
using Mtf.Maui.Controls.Messages;
using Newtonsoft.Json;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace M.A.G.U.S.Assistant.Services;

internal partial class BluetoothService : IBluetoothService, IDisposable
{
    private readonly CommandRegistry registry;
    private readonly ConcurrentDictionary<string, IBluetoothConnection> connections = new();
    private readonly IBluetoothConnector? connector; // optional, injected if app supports outgoing connections
    private readonly Func<Task<IBluetoothListener>>? listenerFactory; // optional factory for server listener
    private readonly IBluetoothDiscoveryService? discovery;

    private CancellationTokenSource? cts;
    private Task? acceptLoopTask;
    private bool isServer;

    //public string LocalId { get; } = "2EE056EE-5939-4EC4-8593-BC606EE1BF9E";
    public string LocalId { get; } = Guid.NewGuid().ToString();

    public event Action<DeviceModel>? DeviceDiscovered;
    public event Func<BluetoothMessage, Task>? MessageReceived;
    public event Func<string, Task>? ClientConnected;    // remoteId
    public event Func<string, Task>? ClientDisconnected; // remoteId

    public BluetoothService(
        CommandRegistry registry,
        IBluetoothConnector? connector,
        IBluetoothDiscoveryService ? discovery,
        Func<Task<IBluetoothListener>>? listenerFactory)
    {
        this.registry = registry ?? throw new ArgumentNullException(nameof(registry));
        this.connector = connector;
        this.listenerFactory = listenerFactory;
        this.discovery = discovery;

        if (discovery != null)
        {
            discovery.DeviceDiscovered += d => DeviceDiscovered?.Invoke(d);
        }
    }

    public static async Task<bool> RequestBluetoothPermissionsAsync()
    {
#if ANDROID
        if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.S)
        {
            // Android 12+ uses specific Bluetooth permissions
            // Note: Make sure BluetoothPermissions maps correctly to BLUETOOTH_SCAN and BLUETOOTH_CONNECT
            var status = await Permissions.RequestAsync<BluetoothPermissions>().ConfigureAwait(false);
            return status == PermissionStatus.Granted;
        }
        else
        {
            // Android 6.0 - 11.0 requires Location permission for discovery
            var status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>().ConfigureAwait(false);
            return status == PermissionStatus.Granted;
        }
#else
        return true;
#endif
    }

    public static bool IsLocationServiceEnabled()
    {
#if ANDROID
    var context = Android.App.Application.Context;
    var locationManager = (LocationManager?)context.GetSystemService(Context.LocationService);

    if (locationManager == null)
    {
        return false;
    }

    // For Android 9.0 (API 28) and above
    if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.P)
    {
        // Suppress CA1416: Only call IsLocationEnabled on API 28+
#pragma warning disable CA1416 // Validate platform compatibility
        return locationManager.IsLocationEnabled;
#pragma warning restore CA1416 // Validate platform compatibility
    }
    else
    {
        // For older Android versions
        return locationManager.IsProviderEnabled(LocationManager.GpsProvider) ||
               locationManager.IsProviderEnabled(LocationManager.NetworkProvider);
    }
#else
    // Default to true for other platforms (Windows, iOS, etc.) unless you implement their specific checks
    return true; 
#endif
    }

    public async Task StartDiscoveryAsync()
    {
        if (!IsLocationServiceEnabled())
        {
            throw new InvalidOperationException("Please turn on your device's Location services to scan for Bluetooth devices.");
        }

        var granted = await RequestBluetoothPermissionsAsync().ConfigureAwait(false);
        if (!granted)
        {
            throw new NotSupportedException("Bluetooth permission denied");
        }

        if (discovery is null)
        {
            throw new NotSupportedException("Discovery not supported on this platform.");
        }

        await discovery.StartDiscoveryAsync().ConfigureAwait(false);
    }

    public async Task StartServerAsync()
    {
        if (listenerFactory is null)
        {
            throw new NotSupportedException("No listener factory provided for server mode.");
        }

        if (cts != null)
        {
            return;
        }
        
        var granted = await RequestBluetoothPermissionsAsync().ConfigureAwait(false);
        if (!granted)
        {
            throw new NotSupportedException("Bluetooth permission denied. Cannot start server.");
        }

        isServer = true;
        cts = new CancellationTokenSource();
        acceptLoopTask = Task.Run(() => AcceptLoopAsync(cts.Token), cts.Token);
    }

    public async Task StopServerAsync()
    {
        var tokenSource = Interlocked.Exchange(ref cts, null);
        if (tokenSource is null)
        {
            return;
        }

        try
        {
            if (discovery != null)
            {
                await discovery.StopDiscoveryAsync().ConfigureAwait(false);
            }
            await tokenSource.CancelAsync().ConfigureAwait(false);

            if (acceptLoopTask is not null)
            {
                try
                {
                    await acceptLoopTask.ConfigureAwait(false);
                }
                catch (OperationCanceledException)
                {
                }
            }

            foreach (var kv in connections.ToArray())
            {
                try
                {
                    kv.Value.Dispose();
                }
                catch
                {
                }
            }

            connections.Clear();
        }
        finally
        {
            tokenSource.Dispose();
            acceptLoopTask = null;
            isServer = false;
        }
    }

    public async Task ConnectAsync(string deviceId)
    {
        if (connector is null)
        {
            throw new NotSupportedException("No connector provided.");
        }

        cts ??= new CancellationTokenSource();

        var ct = cts.Token;
        var conn = await connector.ConnectToAsync(deviceId, ct).ConfigureAwait(false);
        RegisterConnection(conn);
    }

    private async Task AcceptLoopAsync(CancellationToken ct)
    {
        IBluetoothListener listener = await listenerFactory!.Invoke().ConfigureAwait(false);
        try
        {
            while (!ct.IsCancellationRequested)
            {
                try
                {
                    var connection = await listener.AcceptConnectionAsync(ct).ConfigureAwait(false);
                    RegisterConnection(connection);
                }
                catch (OperationCanceledException) { break; }
                catch (Exception ex)
                {
                    ReportError($"AcceptLoop error: {{0}}", ex);
                    await Task.Delay(500, ct).ConfigureAwait(false);
                }
            }
        }
        finally
        {
            listener.Dispose();
        }
    }

    private void RegisterConnection(IBluetoothConnection connection)
    {
        if (!connections.TryAdd(connection.RemoteId, connection))
        {
            // duplicate remote id? dispose new one
            connection.Dispose();
            return;
        }

        _ = Task.Run(() => ReceiveLoopAsync(connection)); // start receive loop
        //_ = ClientConnected?.Invoke(connection.RemoteId);
        _ = Task.Run(async () =>
        {
            try
            {
                await (ClientConnected?.Invoke(connection.RemoteId) ?? Task.CompletedTask);
            }
            catch (Exception ex)
            {
                ReportError($"Register connection failed: {{0}}", ex);
            }
        });
    }

    private async Task ReceiveLoopAsync(IBluetoothConnection connection)
    {
        try
        {
            while (connection.IsConnected && cts?.IsCancellationRequested != true)
            {
                try
                {
                    var json = await connection.ReceiveAsync(cts?.Token ?? CancellationToken.None).ConfigureAwait(false);
                    if (String.IsNullOrEmpty(json))
                    {
                        break;
                    }

                    await OnRawMessageReceived(json, connection.RemoteId).ConfigureAwait(false);
                }
                catch (OperationCanceledException) { break; }
                catch (BluetoothDisconnectedException)
                {
                    break;
                }
                catch (Exception ex)
                {
                    ReportError($"ReceiveLoop error ({connection.RemoteId}): {{0}}", ex);
                    break;
                }
            }
        }
        finally
        {
            CleanupConnection(connection.RemoteId);
        }
    }

    public Task SendAsync(BluetoothMessage message)
    {
        var json = JsonConvert.SerializeObject(message);

        // snapshot the connections to avoid collection mutation issues
        var targets = connections.Values
            .Where(c => message.TargetIds.Count == 0 || message.TargetIds.Contains(c.RemoteId))
            .ToList();

        var sendTasks = targets.Select(c =>
        {
            try
            {
                return c.SendAsync(json, cts?.Token ?? CancellationToken.None);
            }
            catch (Exception ex)
            {
                ReportError($"SendAsync start failed for {c.RemoteId}: {{0}}", ex);
                return Task.CompletedTask;
            }
        }).ToArray();

        return Task.WhenAll(sendTasks);
    }

    private async Task OnRawMessageReceived(string json, string senderId)
    {
        BluetoothMessage? message;
        try
        {
            message = JsonConvert.DeserializeObject<BluetoothMessage>(json);
        }
        catch (Exception ex)
        {
            ReportError($"Invalid JSON from {senderId}: {{0}}", ex);
            return;
        }

        if (message is null)
        {
            return;
        }

        // Server routing: if server and message has targets not including local, forward
        if (isServer && message.TargetIds.Count != 0 && !message.TargetIds.Contains(LocalId))
        {
            await SendAsync(message).ConfigureAwait(false);
            return;
        }

        // Execute command if exists
        if (registry.TryGet(message.CommandType, out var command))
        {
            var context = new CommandContext
            {
                LocalDeviceId = LocalId,
                SenderDeviceId = senderId,
                BluetoothService = this
            };

            try
            {
                await command.ExecuteAsync(context, message.Payload).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                ReportError($"Command {message.CommandType} failed: {{0}}", ex);
            }
        }

        if (MessageReceived is not null)
        {
            await MessageReceived.Invoke(message).ConfigureAwait(false);
        }
    }

    private void CleanupConnection(string remoteId)
    {
        if (connections.TryRemove(remoteId, out IBluetoothConnection? conn))
        {
            try { conn.Dispose(); } catch { }

            _ = Task.Run(async () =>
            {
                try { await (ClientDisconnected?.Invoke(remoteId) ?? Task.CompletedTask); }
                catch (Exception ex) { ReportError($"CleanupConnection failed: {{0}}", ex); }
            });
        }
    }

    public void Dispose()
    {
        cts?.Cancel();

        try
        {
            acceptLoopTask?.Wait(500);
        }
        catch { /* best effort */ }

        foreach (var kv in connections.ToArray())
        {
            try { kv.Value.Dispose(); } catch { }
        }

        cts?.Dispose();
        cts = null;
    }

    private static void ReportError(string titleFormatText, Exception ex)
    {
#if ANDROID
        MainThread.BeginInvokeOnMainThread(() =>  WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex)));
#endif
        Debug.WriteLine(String.Format(titleFormatText, ex));
    }
}