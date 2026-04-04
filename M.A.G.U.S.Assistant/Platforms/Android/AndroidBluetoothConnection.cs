using Android.Bluetooth;
using CommunityToolkit.Mvvm.Messaging;
using M.A.G.U.S.Assistant.Exceptions;
using M.A.G.U.S.Assistant.Interfaces.Bluetooth;
using Mtf.Maui.Controls.Messages;
using System.Net;
using System.Text;

namespace M.A.G.U.S.Assistant.Platforms.Android;

internal sealed class AndroidBluetoothConnection(BluetoothSocket bluetoothSocket) : IBluetoothConnection
{
    private readonly BluetoothSocket socket = bluetoothSocket ?? throw new ArgumentNullException(nameof(bluetoothSocket));
    private readonly SemaphoreSlim sendLock = new(1, 1);
    private readonly string remoteId = bluetoothSocket.RemoteDevice?.Address ?? "Unknown";
    private int disposed;

    public event Func<string, Task>? RawMessageReceived;

    public string RemoteId => remoteId;

    public bool IsConnected
    {
        get
        {
            if (Volatile.Read(ref disposed) != 0)
            {
                return false;
            }

            try
            {
                return socket.IsConnected;
            }
            catch (ObjectDisposedException)
            {
                return false;
            }
        }
    }

    public async Task<string> ReceiveAsync(CancellationToken ct)
    {
        ThrowIfDisposed();

        var stream = socket.InputStream ?? throw new BluetoothDisconnectedException("Bluetooth input stream is unavailable");

        // Read a length prefix first (4 bytes, big-endian int)
        // so we know exactly how many bytes to expect.
        var lengthBuffer = new byte[4];
        await ReadExactAsync(stream, lengthBuffer, 4, ct).ConfigureAwait(false);

        int messageLength = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(lengthBuffer, 0));
        WeakReferenceMessenger.Default.Send(new ShowInfoMessage("ReceiveAsync", $"Expected message length: {messageLength} bytes"));
        if (messageLength <= 0 || messageLength > 1024 * 1024) // sanity cap: 1 MB
        {
            throw new InvalidDataException($"Invalid message length: {messageLength}");
        }

        var messageBuffer = new byte[messageLength];
        await ReadExactAsync(stream, messageBuffer, messageLength, ct).ConfigureAwait(false);

        var result = Encoding.UTF8.GetString(messageBuffer);
        WeakReferenceMessenger.Default.Send(new ShowInfoMessage("ReceiveAsync", $"Read message: {result}"));

        var handler = RawMessageReceived;
        if (handler != null)
        {
            await handler.Invoke(result).ConfigureAwait(false);
        }

        return result;
    }

    // Keeps reading until exactly `count` bytes are filled — crucial for streams.
    private static async Task ReadExactAsync(Stream stream, byte[] buffer, int count, CancellationToken ct)
    {
        var offset = 0;
        while (offset < count)
        {
            ct.ThrowIfCancellationRequested();

            int read;
            try
            {
                read = await stream.ReadAsync(buffer.AsMemory(offset, count - offset), ct).ConfigureAwait(false);
            }
            //catch (OperationCanceledException)
            //{
            //    // Honor cancellation and bubble up so callers can differentiate cancel vs disconnect.
            //    throw;
            //}
            catch (ObjectDisposedException ex)
            {
                throw new BluetoothDisconnectedException("Remote device disconnected (stream disposed)");
            }
            catch (Java.IO.IOException ex)
            {
                // Map platform IO exceptions (including Java.IO.IOException from Android) to a coherent app-level exception.
                throw new BluetoothDisconnectedException("Remote device disconnected (IO error)");
            }
            catch (IOException ex)
            {
                // Map platform IO exceptions (including Java.IO.IOException from Android) to a coherent app-level exception.
                throw new BluetoothDisconnectedException("Remote device disconnected (IO error)");
            }
            catch (Exception ex)
            {
                // Any unexpected exception should also be treated as a disconnection in this read loop.
                throw;
            }
            //var read = await stream.ReadAsync(buffer.AsMemory(offset, count - offset), ct).ConfigureAwait(false);
            if (read <= 0)
            {
                throw new BluetoothDisconnectedException("Remote device disconnected");
            }

            offset += read;
        }
    }

    public async Task SendAsync(string message, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(message);
        ThrowIfDisposed();

        await sendLock.WaitAsync(ct).ConfigureAwait(false);

        try
        {
            ThrowIfDisposed();

            var stream = socket.OutputStream ?? throw new BluetoothDisconnectedException("Bluetooth output stream is unavailable.");

            var payload = Encoding.UTF8.GetBytes(message);
            var lengthPrefix = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(payload.Length));

            await stream.WriteAsync(lengthPrefix, ct).ConfigureAwait(false);
            await stream.WriteAsync(payload, ct).ConfigureAwait(false);
            await stream.FlushAsync(ct).ConfigureAwait(false);

        }
        finally
        {
            try
            {
                sendLock.Release();
            }
            catch (ObjectDisposedException)
            {
            }
        }
    }

    public void Dispose()
    {
        if (Interlocked.Exchange(ref disposed, 1) != 0)
        {
            return;
        }

        try
        {
            socket.Close();
        }
        catch { }

        try
        {
            socket.Dispose();
        }
        catch { }

        sendLock.Dispose();
    }

    private void ThrowIfDisposed()
    {
        ObjectDisposedException.ThrowIf(Volatile.Read(ref disposed) != 0, nameof(AndroidBluetoothConnection));
    }
}
