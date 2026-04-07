#if ANDROID
using Android.Content;
using Android.Locations;
using Android.Bluetooth;
#endif
using CommunityToolkit.Mvvm.Messaging;
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
    private readonly ConcurrentDictionary<string, IBluetoothConnection> pendingConnections = new();
    private readonly ConcurrentDictionary<string, IBluetoothConnection> connections = new();
    private readonly IBluetoothConnector? connector; // optional, injected if app supports outgoing connections
    private readonly Func<Task<IBluetoothListener>>? listenerFactory; // optional factory for server listener
    private readonly IBluetoothDiscoveryService? discovery;

    private CancellationTokenSource? cts;
    private Task? acceptLoopTask;
    private bool isServer;

    public string LocalId { get; }

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

        discovery?.DeviceDiscovered += d => DeviceDiscovered?.Invoke(d);

        // Determine a stable local identifier. Prefer the device Bluetooth MAC
        // address when available (Android). Otherwise fall back to a GUID.
        LocalId = DetermineLocalId();
    }

    private static string DetermineLocalId()
    {
#if ANDROID
        try
        {
            var adapter = BluetoothAdapter.DefaultAdapter;
            if (adapter != null)
            {
                var addr = adapter.Address;
                // Android may return a placeholder address for privacy on newer OS versions.
                if (!String.IsNullOrWhiteSpace(addr) && addr != "02:00:00:00:00:00")
                {
                    return addr;
                }
            }
        }
        catch
        {
            // ignore and fall back to GUID below
        }
#endif
        return Guid.NewGuid().ToString();
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

    public async Task<bool> StartDiscoveryAsync()
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

        return discovery.StartDiscovery();
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
            discovery?.StopDiscovery();
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

    public async Task ConnectAsync(string macAddress)
    {
        if (connector is null)
        {
            throw new NotSupportedException("No connector provided.");
        }

        cts ??= new CancellationTokenSource();
        var connection = await connector.ConnectToAsync(macAddress).ConfigureAwait(false);
        RegisterConnection(connection);
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
        //if (!connections.TryAdd(LocalId, connection))
        //{
        //    // duplicate remote id? dispose new one
        //    connection.Dispose();
        //    return;
        //}
        pendingConnections[connection.MacAddress] = connection;
        FireAndForget(ReceiveLoopAsync(connection), "ReceiveLoopAsync");
        FireAndForget(NotifyClientConnectedAsync(connection), "ClientConnected notification");
    }

    private async Task NotifyClientConnectedAsync(IBluetoothConnection connection)
    {
        if (ClientConnected is null)
        {
            return;
        }

        await (ClientConnected.Invoke(connection.MacAddress) ?? Task.CompletedTask).ConfigureAwait(false);
    }

    private static void FireAndForget(Task task, string operationName)
    {
        _ = task.ContinueWith(t =>
        {
            if (t.Exception != null)
            {
                ReportError($"{operationName} failed: {{0}}", t.Exception.Flatten());
            }
        },
        CancellationToken.None,
        TaskContinuationOptions.OnlyOnFaulted,
        TaskScheduler.Default);
    }

    private async Task ReceiveLoopAsync(IBluetoothConnection connection)
    {
        ArgumentNullException.ThrowIfNull(connection);

        var token = cts?.Token ?? CancellationToken.None;

        try
        {
            while (!token.IsCancellationRequested && connection.IsConnected)
            {
                try
                {
                    var json = await connection.ReceiveAsync(token).ConfigureAwait(false);
                    if (String.IsNullOrEmpty(json))
                    {
                        break;
                    }

                    await OnRawMessageReceived(json, connection).ConfigureAwait(false);
                }
                catch (BluetoothDisconnectedException ex)
                {
                    break;
                }
                catch (Exception ex)
                {
                    ReportError($"ReceiveLoop error ({connection.MacAddress}): {{0}}", ex);
                    break;
                }
            }
        }
        finally
        {
            CleanupConnection(connection);
        }
    }

    public Task SendAsync(BluetoothMessage message)
    {
        var json = JsonConvert.SerializeObject(message);

        // snapshot the connections to avoid collection mutation issues
        //var targets = connections.Values
        //    .Where(c => message.TargetIds.Count == 0 || message.TargetIds.Contains(c.MacAddress))
        //    .ToList();
        var targets = connections
            .Where(kv => message.TargetIds.Count == 0 || message.TargetIds.Contains(kv.Key))
            .Select(kv => kv.Value)
            .Distinct()
            .ToList();
        var sendTasks = targets.Select(c => c.SendAsync(json, cts?.Token ?? CancellationToken.None));

        //var sendTasks = targets.Select(c =>
        //{
        //    try
        //    {
        //        return c.SendAsync(json, cts?.Token ?? CancellationToken.None);
        //    }
        //    catch (Exception ex)
        //    {
        //        ReportError($"SendAsync start failed for {c.MacAddress}: {{0}}", ex);
        //        return Task.CompletedTask;
        //    }
        //}).ToArray();

        return Task.WhenAll(sendTasks);
    }

    private async Task OnRawMessageReceived(string json, IBluetoothConnection connection)
    {
        //WeakReferenceMessenger.Default.Send(new ShowInfoMessage($"SenderId: {senderMacAddress}", json));

        BluetoothMessage? message;
        try
        {
            message = JsonConvert.DeserializeObject<BluetoothMessage>(json);
        }
        catch (Exception ex)
        {
            ReportError($"Invalid JSON from {connection.MacAddress}: {{0}}", ex);
            return;
        }

        if (message is null)
        {
            return;
        }

        if (message.CommandType == Enums.BluetoothCommandType.RegisterPlayer)
        {
            pendingConnections.TryRemove(connection.MacAddress, out _);
            connections[message.SenderId] = connection;
            //if (!connections.TryAdd(message.SenderId, connection))
            //{
            //    connection.Dispose();
            //}
        }

        var isBroadcast = message.TargetIds.Count == 0;

        if (isServer)
        {
            var isForServer = !String.IsNullOrEmpty(LocalId) && message.TargetIds.Contains(LocalId);
            var isForOthers = isBroadcast || message.TargetIds.Any(id => id != message.SenderId);

            if (isForOthers)
            {
                try
                {
                    var forwardTasks = connections
                        .Where(kv => kv.Key != message.SenderId && (isBroadcast || message.TargetIds.Contains(kv.Key)))
                        .Select(kv => kv.Value.SendAsync(json, cts?.Token ?? CancellationToken.None));

                    //var forwardTasks = connections.Values
                    //    .Where(c => c.MacAddress != connection.MacAddress && (isBroadcast || message.TargetIds.Contains(c.MacAddress)))
                    //    .Select(c => c.SendAsync(json, cts?.Token ?? CancellationToken.None));

                    await Task.WhenAll(forwardTasks).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    ReportError($"Forwarding failed: {{0}}", ex);
                }
            }

            if (!isBroadcast && !isForServer)
            {
                return;
            }
        }

        // Server routing: if server and message has targets not including local, forward
        //if (isServer)
        //{
        //    await SendAsync(message).ConfigureAwait(false);
        //    return;
        //}

        // Execute command if exists
        if (registry.TryGet(message.CommandType, out var command))
        {
            var context = new CommandContext
            {
                LocalDeviceId = LocalId, // Is this ok? message.SenderId?
                SenderMacAddress = connection.MacAddress,
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

    //private void CleanupConnection(string remoteId)
    //{
    //    if (connections.TryRemove(remoteId, out IBluetoothConnection? conn))
    //    {
    //        try { conn.Dispose(); } catch { }

    //        _ = Task.Run(async () =>
    //        {
    //            try { await (ClientDisconnected?.Invoke(remoteId) ?? Task.CompletedTask); }
    //            catch (Exception ex) { ReportError($"CleanupConnection failed: {{0}}", ex); }
    //        });
    //    }
    //}
    private void CleanupConnection(IBluetoothConnection connection)
    {
        pendingConnections.TryRemove(connection.MacAddress, out _);

        var registered = connections
            .Where(kv => ReferenceEquals(kv.Value, connection))
            .Select(kv => kv.Key)
            .ToList();

        foreach (var key in registered)
        {
            connections.TryRemove(key, out _);
        }

        try
        {
            connection.Dispose();
        }
        catch
        {
        }

        _ = Task.Run(async () =>
        {
            try
            {
                await (ClientDisconnected?.Invoke(connection.MacAddress) ?? Task.CompletedTask);
            }
            catch (Exception ex)
            {
                ReportError("CleanupConnection failed: {0}", ex);
            }
        });
    }

    public void Dispose()
    {
        var tokenSource = Interlocked.Exchange(ref cts, null);

        try
        {
            tokenSource?.Cancel();

            try
            {
                acceptLoopTask?.Wait(500);
            }
            catch
            {
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
            tokenSource?.Dispose();
            acceptLoopTask = null;
            isServer = false;
        }
    }

    private static void ReportError(string titleFormatText, Exception ex)
    {
        FireAndForget(MauiProgram.OpenEmailClientWithErrorAsync(ex), "ReportError");
#if ANDROID
        MainThread.BeginInvokeOnMainThread(() => WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex)));
#endif
        Debug.WriteLine(String.Format(titleFormatText, ex));
    }
}