using M.A.G.U.S.Assistant.Interfaces.Bluetooth;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;

namespace M.A.G.U.S.Assistant.Platforms.Windows;

internal sealed partial class WindowsBluetoothConnection : IBluetoothConnection
{
    private readonly StreamSocket socket;

    public string MacAddress => socket.Information.RemoteAddress?.DisplayName ?? "Unknown";

    public bool IsConnected => true;

    public event Func<string, Task>? RawMessageReceived;

    public WindowsBluetoothConnection(StreamSocket socket)
    {
        this.socket = socket;
        _ = StartReceiveLoop();
    }

    private async Task StartReceiveLoop()
    {
        var reader = new DataReader(socket.InputStream);
        try
        {
            while (IsConnected)
            {
                uint size = await reader.LoadAsync(1024);
                if (size == 0)
                {
                    break;
                }

                string msg = reader.ReadString(size);
                if (RawMessageReceived != null)
                {
                    await RawMessageReceived.Invoke(msg);
                }
            }
        }
        catch { /* connection closed */ }
    }

    public async Task<string> ReceiveAsync(CancellationToken ct)
    {
        var reader = new DataReader(socket.InputStream);
        uint size = await reader.LoadAsync(1024).AsTask(ct);
        return reader.ReadString(size);
    }

    public async Task SendAsync(string json, CancellationToken ct = default)
    {
        var writer = new DataWriter(socket.OutputStream);
        writer.WriteString(json);
        await writer.StoreAsync();
        writer.DetachStream();
    }

    public void Dispose()
    {
        try { socket.Dispose(); } catch { }
    }
}
