using Android.Bluetooth;
using M.A.G.U.S.Assistant.Interfaces.Bluetooth;

namespace M.A.G.U.S.Assistant.Platforms.Android;

internal sealed class AndroidBluetoothListener : IBluetoothListener
{
    private BluetoothServerSocket? serverSocket;

    public Task<IBluetoothConnection> AcceptConnectionAsync(CancellationToken ct)
    {
        if (serverSocket == null)
        {
            var adapter = BluetoothAdapter.DefaultAdapter;
            serverSocket = adapter.ListenUsingRfcommWithServiceRecord("MAGUS_Service", AndroidBluetoothConnector.ServiceUuid);
        }

        return Task.Run(async () =>
        {
            ct.Register(() =>
            {
                try { serverSocket?.Close(); } catch { }
                serverSocket = null;
            });
            var socket = await serverSocket.AcceptAsync().ConfigureAwait(false);
            return (IBluetoothConnection)new AndroidBluetoothConnection(socket);
        }, ct);
    }

    public void Dispose()
    {
        try { serverSocket?.Close(); } catch { }
    }
}