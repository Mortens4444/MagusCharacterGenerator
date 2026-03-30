using Android.Bluetooth;
using CommunityToolkit.Mvvm.Messaging;
using M.A.G.U.S.Assistant.Interfaces.Bluetooth;
using Mtf.Maui.Controls.Messages;

namespace M.A.G.U.S.Assistant.Platforms.Android;

internal sealed class AndroidBluetoothListener : IBluetoothListener
{
    private readonly object syncRoot = new();
    private BluetoothServerSocket? serverSocket;

    public Task<IBluetoothConnection> AcceptConnectionAsync(CancellationToken ct)
    {
        lock (syncRoot)
        {
            serverSocket ??= BluetoothAdapter.DefaultAdapter?.ListenUsingRfcommWithServiceRecord(
            "MAGUS_Service",
            AndroidBluetoothConnector.ServiceUuid)
            ?? throw new NotSupportedException("Bluetooth not supported");

            var localSocket = serverSocket;

            return Task.Run(async () =>
            {
                using var reg = ct.Register(() =>
                {
                    try
                    {
                        localSocket?.Close();
                    }
                    catch (Exception ex)
                    {
                        WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
                    }
                    serverSocket = null;
                });

                if (localSocket == null)
                {
                    throw new ArgumentNullException(nameof(localSocket));
                }
                var socket = await localSocket.AcceptAsync().ConfigureAwait(false);
                // reg is disposed here — cancellation callback is unregistered cleanly
                return (IBluetoothConnection)new AndroidBluetoothConnection(socket!);

                //ct.Register(() =>
                //{
                //    try { localSocket?.Close(); } catch { }
                //    serverSocket = null;
                //});
                //var socket = await localSocket.AcceptAsync().ConfigureAwait(false);
                //return (IBluetoothConnection)new AndroidBluetoothConnection(socket);
            }, ct);
        }
    }

    public void Dispose()
    {
        try { serverSocket?.Close(); } catch { }
    }
}