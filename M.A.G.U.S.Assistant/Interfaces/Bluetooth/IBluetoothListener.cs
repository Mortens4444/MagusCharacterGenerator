namespace M.A.G.U.S.Assistant.Interfaces.Bluetooth;

internal interface IBluetoothListener : IDisposable
{
    /// <summary>Accepts an incoming connection or cancels.</summary>
    Task<IBluetoothConnection> AcceptConnectionAsync(CancellationToken ct);
}
