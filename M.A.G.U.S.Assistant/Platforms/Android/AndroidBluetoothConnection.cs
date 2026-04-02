using Android.Bluetooth;
using CommunityToolkit.Mvvm.Messaging;
using M.A.G.U.S.Assistant.Exceptions;
using M.A.G.U.S.Assistant.Interfaces.Bluetooth;
using Mtf.Maui.Controls.Messages;
using System.Net;
using System.Text;

namespace M.A.G.U.S.Assistant.Platforms.Android;

internal sealed class AndroidBluetoothConnection : IBluetoothConnection
{
    private readonly BluetoothSocket socket;
    private readonly SemaphoreSlim sendLock = new(1, 1);
    private readonly string remoteId;
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

    public AndroidBluetoothConnection(BluetoothSocket socket)
    {
        this.socket = socket ?? throw new ArgumentNullException(nameof(socket));
        remoteId = socket.RemoteDevice?.Address ?? "Unknown";
    }

    public async Task<string?> ReceiveAsync(CancellationToken ct)
    {
        ThrowIfDisposed();
        
        var stream = socket.InputStream ?? throw new BluetoothDisconnectedException("Bluetooth input stream is unavailable.");

        // Read a length prefix first (4 bytes, big-endian int)
        // so we know exactly how many bytes to expect.
        var lengthBuffer = new byte[4];
        await ReadExactAsync(stream, lengthBuffer, 4, ct).ConfigureAwait(false);

        int messageLength = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(lengthBuffer, 0));
        if (messageLength <= 0 || messageLength > 1024 * 1024) // sanity cap: 1 MB
        {
            throw new InvalidDataException($"Invalid message length: {messageLength}");
        }

        var messageBuffer = new byte[messageLength];
        await ReadExactAsync(stream, messageBuffer, messageLength, ct).ConfigureAwait(false);

        var result = Encoding.UTF8.GetString(messageBuffer);

        if (RawMessageReceived != null)
        {
            try
            {
                await RawMessageReceived.Invoke(result).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
            }
        }

        return result;
    }

    // Keeps reading until exactly `count` bytes are filled — crucial for streams.
    private async Task ReadExactAsync(Stream stream, byte[] buffer, int count, CancellationToken ct)
    {
        int offset = 0;
        while (offset < count)
        {
            ct.ThrowIfCancellationRequested();
            if (socket.InputStream == null || socket.OutputStream == null)
            {
                throw new InvalidOperationException("Bluetooth socket streams are not available.");
            }

            try
            {
                int read = await socket.InputStream!
                        .ReadAsync(buffer.AsMemory(offset, count - offset), ct)
                        .ConfigureAwait(false);

                if (read <= 0)
                {
                    throw new BluetoothDisconnectedException("Remote device disconnected.");
                }

                offset += read;
            }
            catch (ObjectDisposedException)
            {
                throw new BluetoothDisconnectedException("Bluetooth socket was disposed while reading.");
            }
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
        catch (ObjectDisposedException)
        {
            throw new BluetoothDisconnectedException("Bluetooth socket was disposed.");
        }
        finally
        {
            sendLock.Release();
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
