using Android.Bluetooth;
using M.A.G.U.S.Assistant.Interfaces.Bluetooth;

namespace M.A.G.U.S.Assistant.Platforms.Android;

internal sealed class AndroidBluetoothListener : IBluetoothListener
{
    private BluetoothServerSocket? serverSocket;

    public async Task<IBluetoothConnection> AcceptConnectionAsync(CancellationToken ct)
    {
        if (serverSocket == null)
        {
            var adapter = BluetoothAdapter.DefaultAdapter;
            serverSocket = adapter.ListenUsingRfcommWithServiceRecord(
                "MAGUS_Service", Java.Util.UUID.RandomUUID());
        }

        return await Task.Run(() =>
        {
            BluetoothSocket socket = serverSocket.Accept();
            return (IBluetoothConnection)new AndroidBluetoothConnection(socket);
        }, ct);
    }

    public void Dispose()
    {
        try { serverSocket?.Close(); } catch { }
    }
}