using Android.Bluetooth;
using M.A.G.U.S.Assistant.Interfaces.Bluetooth;
using System.Text;

namespace M.A.G.U.S.Assistant.Platforms.Android;

internal sealed class AndroidBluetoothConnection : IBluetoothConnection
{
    private readonly BluetoothSocket _socket;


    public event Func<string, Task>? RawMessageReceived;

    public string RemoteId => _socket.RemoteDevice?.Address ?? "Unknown";

    public bool IsConnected => _socket.IsConnected;

    public AndroidBluetoothConnection(BluetoothSocket socket)
    {
        _socket = socket;
    }

    public async Task<string> ReceiveAsync(CancellationToken ct)
    {
        var buffer = new byte[1024];
        int read = await _socket.InputStream.ReadAsync(buffer, 0, buffer.Length, ct);
        var result = Encoding.UTF8.GetString(buffer, 0, read);
        if (RawMessageReceived != null)
        {
            await RawMessageReceived.Invoke(result);
        }
        return result;
    }

    public async Task SendAsync(string json)
    {
        var bytes = Encoding.UTF8.GetBytes(json);
        await _socket.OutputStream.WriteAsync(bytes, 0, bytes.Length);
    }

    public void Dispose()
    {
        try { _socket.Close(); } catch { }
    }
}
