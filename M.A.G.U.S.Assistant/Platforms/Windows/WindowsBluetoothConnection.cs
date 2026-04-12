using M.A.G.U.S.Assistant.Interfaces.Bluetooth;
using System.Net;
using System.Text;
using global::Windows.Networking.Sockets;
using global::Windows.Storage.Streams;

namespace M.A.G.U.S.Assistant.Platforms.Windows;

internal sealed partial class WindowsBluetoothConnection : IBluetoothConnection
{
    private readonly StreamSocket socket;
    private readonly string macAddress;
    private readonly DataReader reader;
    private readonly SemaphoreSlim sendLock = new(1, 1);
    private readonly SemaphoreSlim receiveLock = new(1, 1);
    private int disposed;

    public string MacAddress => macAddress;

    public bool IsConnected => Volatile.Read(ref disposed) == 0;

    public event Func<string, Task>? RawMessageReceived;

    public WindowsBluetoothConnection(StreamSocket socket, string macAddress)
    {
        this.socket = socket ?? throw new ArgumentNullException(nameof(socket));
        this.macAddress = String.IsNullOrWhiteSpace(macAddress) ? "Unknown" : macAddress;

        var inputStream = this.socket.InputStream ?? throw new IOException("Bluetooth input stream is unavailable.");
        reader = new DataReader(inputStream)
        {
            InputStreamOptions = InputStreamOptions.Partial
        };
    }

    public async Task<string> ReceiveAsync(CancellationToken ct)
    {
        ThrowIfDisposed();
        await receiveLock.WaitAsync(ct).ConfigureAwait(false);

        try
        {
            ThrowIfDisposed();

            var lengthBuffer = new byte[4];
            await ReadExactAsync(lengthBuffer, ct).ConfigureAwait(false);

            var messageLength = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(lengthBuffer, 0));
            if (messageLength <= 0 || messageLength > 1024 * 1024)
            {
                throw new InvalidDataException($"Invalid message length: {messageLength}");
            }

            var payload = new byte[messageLength];
            await ReadExactAsync(payload, ct).ConfigureAwait(false);

            var message = Encoding.UTF8.GetString(payload);

            var handler = RawMessageReceived;
            if (handler != null)
            {
                await handler.Invoke(message).ConfigureAwait(false);
            }

            return message;
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (ObjectDisposedException)
        {
            throw new IOException("Remote device disconnected.");
        }
        catch (Exception ex) when (IsSocketDisposedLike(ex))
        {
            throw new IOException("Remote device disconnected.", ex);
        }
        finally
        {
            receiveLock.Release();
        }
    }

    public async Task SendAsync(string json, CancellationToken ct = default)
    {
        ArgumentNullException.ThrowIfNull(json);
        ThrowIfDisposed();

        await sendLock.WaitAsync(ct).ConfigureAwait(false);

        try
        {
            ThrowIfDisposed();

            var stream = socket.OutputStream ?? throw new IOException("Bluetooth output stream is unavailable.");
            using var writer = new DataWriter(stream);

            var payload = Encoding.UTF8.GetBytes(json);
            var lengthPrefix = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(payload.Length));

            writer.WriteBytes(lengthPrefix);
            writer.WriteBytes(payload);

            await writer.StoreAsync().AsTask(ct).ConfigureAwait(false);
            await writer.FlushAsync().AsTask(ct).ConfigureAwait(false);

            // Ne zárja le az output streamet dispose-nál.
            writer.DetachStream();
        }
        catch (ObjectDisposedException)
        {
            throw new IOException("Remote device disconnected.");
        }
        catch (Exception ex) when (IsSocketDisposedLike(ex))
        {
            throw new IOException("Remote device disconnected.", ex);
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
            reader.DetachStream();
        }
        catch
        {
        }

        try
        {
            reader.Dispose();
        }
        catch
        {
        }

        try
        {
            socket.Dispose();
        }
        catch
        {
        }

        receiveLock.Dispose();
        sendLock.Dispose();
    }

    private async Task ReadExactAsync(byte[] buffer, CancellationToken ct)
    {
        var offset = 0;

        while (offset < buffer.Length)
        {
            ThrowIfDisposed();
            ct.ThrowIfCancellationRequested();

            var remaining = (uint)(buffer.Length - offset);
            var loaded = await reader.LoadAsync(remaining).AsTask(ct).ConfigureAwait(false);

            if (loaded == 0)
            {
                throw new IOException("Remote device disconnected.");
            }

            var chunk = new byte[loaded];
            reader.ReadBytes(chunk);

            var copyLength = Math.Min(chunk.Length, buffer.Length - offset);
            Array.Copy(chunk, 0, buffer, offset, copyLength);
            offset += copyLength;
        }
    }

    private static bool IsSocketDisposedLike(Exception ex)
    {
        return ex is IOException
            || ex is ObjectDisposedException
            || ex.GetType().FullName?.Contains("COMException", StringComparison.Ordinal) == true;
    }

    private void ThrowIfDisposed()
    {
        ObjectDisposedException.ThrowIf(Volatile.Read(ref disposed) != 0, nameof(WindowsBluetoothConnection));
    }
}