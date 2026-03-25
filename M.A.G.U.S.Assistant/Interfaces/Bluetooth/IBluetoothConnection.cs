namespace M.A.G.U.S.Assistant.Interfaces.Bluetooth;

internal interface IBluetoothConnection : IDisposable
{
    string RemoteId { get; }

    bool IsConnected { get; }

    /// <summary>Send a JSON string over the connection.</summary>
    Task SendAsync(string json, CancellationToken ct = default);

    /// <summary>Receive a JSON string or null if closed.</summary>
    Task<string?> ReceiveAsync(CancellationToken ct);

    event Func<string, Task>? RawMessageReceived;
}
