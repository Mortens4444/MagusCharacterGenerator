using M.A.G.U.S.Assistant.Contexts;
using M.A.G.U.S.Assistant.Interfaces.Bluetooth;
using M.A.G.U.S.Assistant.Messages;
using M.A.G.U.S.Assistant.Models.Bluetooth;
using Newtonsoft.Json;
using System.Collections.Concurrent;

namespace M.A.G.U.S.Assistant.Services;

internal sealed class BluetoothService : IBluetoothService, IDisposable
{
    private readonly CommandRegistry registry;
    private readonly ConcurrentDictionary<string, IBluetoothConnection> connections = new();
    private readonly IBluetoothConnector? connector; // optional, injected if app supports outgoing connections
    private readonly Func<Task<IBluetoothListener>>? listenerFactory; // optional factory for server listener
    private readonly IBluetoothDiscoveryService? discovery;

    private CancellationTokenSource? cts;
    private Task? acceptLoopTask;
    private bool isServer;

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

    public Task StartDiscoveryAsync()
    {
        if (discovery is null)
        {
            throw new NotSupportedException("Discovery not supported on this platform.");
        }

        return discovery.StartDiscoveryAsync();
    }

    public Task StartServerAsync()
    {
        if (listenerFactory is null)
        {
            throw new NotSupportedException("No listener factory provided for server mode.");
        }

        if (cts != null)
        {
            return Task.CompletedTask;
        }

        isServer = true;
        cts = new CancellationTokenSource();
        acceptLoopTask = Task.Run(() => AcceptLoopAsync(cts.Token), cts.Token);
        return Task.CompletedTask;
    }

    public async Task StopServerAsync()
    {
        if (cts is null)
        {
            return;
        }

        try
        {
            cts.Cancel();

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
            cts.Dispose();
            cts = null;
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

        if (cts is null)
        {
            cts = new CancellationTokenSource();
        }

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
                    // log or surface error, then continue accepting
                    System.Diagnostics.Debug.WriteLine($"AcceptLoop error: {ex}");
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
        _ = ClientConnected?.Invoke(connection.RemoteId);
    }

    private async Task ReceiveLoopAsync(IBluetoothConnection connection)
    {
        try
        {
            while (connection.IsConnected && (cts is null || !cts.IsCancellationRequested))
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
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"ReceiveLoop error ({connection.RemoteId}): {ex}");
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
                return c.SendAsync(json);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"SendAsync start failed for {c.RemoteId}: {ex}");
                return Task.CompletedTask;
            }
        }).ToArray();

        return Task.WhenAll(sendTasks);
    }

    private async Task OnRawMessageReceived(string json, string senderId)
    {
        BluetoothMessage? message = null;
        try
        {
            message = JsonConvert.DeserializeObject<BluetoothMessage>(json);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Invalid JSON from {senderId}: {ex}");
            return;
        }

        if (message is null)
        {
            return;
        }

        // Server routing: if server and message has targets not including local, forward
        if (isServer && message.TargetIds.Any() && !message.TargetIds.Contains(LocalId))
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
                System.Diagnostics.Debug.WriteLine($"Command {message.CommandType} failed: {ex}");
            }
        }

        if (MessageReceived is not null)
        {
            await MessageReceived.Invoke(message).ConfigureAwait(false);
        }
    }

    private void CleanupConnection(string remoteId)
    {
        if (connections.TryRemove(remoteId, out var conn))
        {
            try { conn.Dispose(); } catch { }
            _ = ClientDisconnected?.Invoke(remoteId);
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

        _ = discovery?.StopDiscoveryAsync();
    }
}