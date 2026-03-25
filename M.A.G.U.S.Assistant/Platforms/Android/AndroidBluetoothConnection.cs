using Android.Bluetooth;
using M.A.G.U.S.Assistant.Interfaces.Bluetooth;
using System.Text;

namespace M.A.G.U.S.Assistant.Platforms.Android;

internal sealed class AndroidBluetoothConnection : IBluetoothConnection
{
    private readonly BluetoothSocket socket;
    private readonly SemaphoreSlim sendLock = new(1, 1);

    public event Func<string, Task>? RawMessageReceived;
    public string RemoteId => socket.RemoteDevice?.Address ?? "Unknown";
    public bool IsConnected => socket.IsConnected;

    public AndroidBluetoothConnection(BluetoothSocket socket)
    {
        this.socket = socket;
    }

    public async Task<string> ReceiveAsync(CancellationToken ct)
    {
        // Read a length prefix first (4 bytes, big-endian int)
        // so we know exactly how many bytes to expect.
        var lengthBuffer = new byte[4];
        await ReadExactAsync(lengthBuffer, 4, ct).ConfigureAwait(false);
        int messageLength = System.Net.IPAddress.NetworkToHostOrder(
            BitConverter.ToInt32(lengthBuffer, 0));

        if (messageLength <= 0 || messageLength > 1024 * 1024) // sanity cap: 1 MB
        {
            throw new InvalidDataException($"Invalid message length: {messageLength}");
        }

        var messageBuffer = new byte[messageLength];
        await ReadExactAsync(messageBuffer, messageLength, ct).ConfigureAwait(false);

        var result = Encoding.UTF8.GetString(messageBuffer);

        if (RawMessageReceived != null)
            await RawMessageReceived.Invoke(result).ConfigureAwait(false);

        return result;
    }

    // Keeps reading until exactly `count` bytes are filled — crucial for streams.
    private async Task ReadExactAsync(byte[] buffer, int count, CancellationToken ct)
    {
        int offset = 0;
        while (offset < count)
        {
            ct.ThrowIfCancellationRequested();
            int read = await socket.InputStream!
                .ReadAsync(buffer, offset, count - offset, ct)
                .ConfigureAwait(false);

            if (read <= 0)
                throw new IOException("Bluetooth connection lost (read returned 0 or -1).");

            offset += read;
        }
    }

    public async Task SendAsync(string json, CancellationToken ct = default)
    {
        var payload = Encoding.UTF8.GetBytes(json);
        var lengthPrefix = BitConverter.GetBytes(
            System.Net.IPAddress.HostToNetworkOrder(payload.Length));

        // Serialize sends so concurrent calls don't interleave bytes.
        await sendLock.WaitAsync(ct).ConfigureAwait(false);
        try
        {
            await socket.OutputStream!.WriteAsync(lengthPrefix, 0, 4).ConfigureAwait(false);
            await socket.OutputStream!.WriteAsync(payload, 0, payload.Length).ConfigureAwait(false);
        }
        finally
        {
            sendLock.Release();
        }
    }

    public void Dispose()
    {
        sendLock.Dispose();
        try { socket.Close(); } catch { }
    }
}
