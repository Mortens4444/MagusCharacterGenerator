using M.A.G.U.S.Assistant.Interfaces.Bluetooth;

namespace M.A.G.U.S.Assistant.Stubs;

internal sealed class StubBluetoothListener : IBluetoothListener
{
    public Task<IBluetoothConnection> AcceptConnectionAsync(CancellationToken ct)
    {
        // csak egy dummy connection visszaadása
        IBluetoothConnection conn = new StubBluetoothConnection();
        return Task.FromResult(conn);
    }

    public void Dispose() { }
}

internal sealed class StubBluetoothConnection : IBluetoothConnection
{
    public string RemoteId => "Stub Bluetooth Connection";
    
    public bool IsConnected => true;

    public event Func<string, Task>? RawMessageReceived;

    public void Dispose() { }
    
    public Task<string> ReceiveAsync(CancellationToken ct) => Task.FromResult(String.Empty);
    
    public Task SendAsync(string json, CancellationToken ct = default) => Task.CompletedTask;
}