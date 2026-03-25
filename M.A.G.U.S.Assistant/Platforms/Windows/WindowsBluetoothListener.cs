using M.A.G.U.S.Assistant.Interfaces.Bluetooth;
using Windows.Networking.Sockets;

namespace M.A.G.U.S.Assistant.Platforms.Windows;

internal partial class WindowsBluetoothListener : IBluetoothListener
{
    private StreamSocketListener? listener;

    public async Task<IBluetoothConnection> AcceptConnectionAsync(CancellationToken ct)
    {
        listener ??= new StreamSocketListener();
        var tcs = new TaskCompletionSource<IBluetoothConnection>();

        listener.ConnectionReceived += (sender, args) =>
        {
            tcs.TrySetResult(new WindowsBluetoothConnection(args.Socket));
        };

        await listener.BindServiceNameAsync("MAGUS_Service");
        using (ct.Register(() => tcs.TrySetCanceled()))
        {
            return await tcs.Task.ConfigureAwait(false);
        }
    }

    public void Dispose()
    {
        try { listener?.Dispose(); } catch { }
    }
}