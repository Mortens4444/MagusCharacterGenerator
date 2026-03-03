using M.A.G.U.S.Assistant.Interfaces.Bluetooth;
using Windows.Networking.Sockets;

namespace M.A.G.U.S.Assistant.Platforms.Windows;

internal sealed class WindowsBluetoothListener : IBluetoothListener
{
    private StreamSocketListener? _listener;

    public async Task<IBluetoothConnection> AcceptConnectionAsync(CancellationToken ct)
    {
        _listener ??= new StreamSocketListener();
        var tcs = new TaskCompletionSource<IBluetoothConnection>();

        _listener.ConnectionReceived += (sender, args) =>
        {
            tcs.TrySetResult(new WindowsBluetoothConnection(args.Socket));
        };

        await _listener.BindServiceNameAsync("MAGUS_Service");
        using (ct.Register(() => tcs.TrySetCanceled()))
        {
            return await tcs.Task;
        }
    }

    public void Dispose()
    {
        try { _listener?.Dispose(); } catch { }
    }
}