using Android.Bluetooth;
using M.A.G.U.S.Assistant.Interfaces.Bluetooth;

namespace M.A.G.U.S.Assistant.Platforms.Android;

internal sealed class AndroidBluetoothListener : IBluetoothListener
{
    private readonly Lock syncRoot = new();
    private BluetoothServerSocket? serverSocket;
    private bool disposed;

    public async Task<IBluetoothConnection> AcceptConnectionAsync(CancellationToken ct)
    {
        var adapter = BluetoothAdapter.DefaultAdapter ?? throw new NotSupportedException("Bluetooth not supported.");
        if (!adapter.IsEnabled)
        {
            throw new InvalidOperationException("Bluetooth is disabled.");
        }

        BluetoothServerSocket? localSocket;
        lock (syncRoot)
        {
            ObjectDisposedException.ThrowIf(disposed, nameof(AndroidBluetoothListener));

            serverSocket ??= adapter.ListenUsingRfcommWithServiceRecord("MAGUS_Service", AndroidBluetoothConnector.ServiceUuid)
                ?? throw new NotSupportedException("Bluetooth not supported.");

            localSocket = serverSocket;
        }

        using var registration = ct.Register(() =>
        {
            lock (syncRoot)
            {
                if (ReferenceEquals(serverSocket, localSocket))
                {
                    CloseServerSocket(ref serverSocket);
                    localSocket = null;
                }
                else
                {
                    CloseServerSocket(ref localSocket);
                }
            }
        });

        try
        {
            var socket = await localSocket.AcceptAsync().ConfigureAwait(false) ?? throw new InvalidOperationException("Bluetooth accept returned null socket.");
            return new AndroidBluetoothConnection(socket);
        }
        catch when (ct.IsCancellationRequested)
        {
            throw new OperationCanceledException(ct);
        }
        catch
        {
            lock (syncRoot)
            {
                if (ReferenceEquals(serverSocket, localSocket))
                {
                    CloseServerSocket(ref serverSocket);
                }
            }

            throw;
        }
    }

    public void Dispose()
    {
        lock (syncRoot)
        {
            if (disposed)
            {
                return;
            }

            disposed = true;

            CloseServerSocket(ref serverSocket);
        }
    }

    private static void CloseServerSocket(ref BluetoothServerSocket? bluetoothServerSocket)
    {
        try
        {
            bluetoothServerSocket?.Close();
        }
        catch { }
        try
        {
            bluetoothServerSocket?.Dispose();
        }
        catch { }
        bluetoothServerSocket = null;
    }
}