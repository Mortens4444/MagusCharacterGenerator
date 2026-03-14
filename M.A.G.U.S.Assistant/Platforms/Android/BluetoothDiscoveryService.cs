using Android.Bluetooth;
using Android.Content;
using M.A.G.U.S.Assistant.Interfaces.Bluetooth;
using M.A.G.U.S.Assistant.Models.Bluetooth;

namespace M.A.G.U.S.Assistant.Platforms.Android;

internal sealed class BluetoothDiscoveryService(Context context)
    : BroadcastReceiver, IBluetoothDiscoveryService
{
    private readonly BluetoothAdapter adapter = BluetoothAdapter.DefaultAdapter;
    private readonly Context context = context;

    public event Action<DeviceModel>? DeviceDiscovered;

    public Task StartDiscoveryAsync(CancellationToken cancellationToken = default)
    {
        if (adapter == null || !adapter.IsEnabled)
        {
            return Task.CompletedTask;
        }

        var filter = new IntentFilter(BluetoothDevice.ActionFound);
        context.RegisterReceiver(this, filter);

        if (adapter.IsDiscovering)
        {
            adapter.CancelDiscovery();
        }

        adapter.StartDiscovery();

        return Task.CompletedTask;
    }

    public Task StopDiscoveryAsync()
    {
        if (adapter?.IsDiscovering == true)
        {
            adapter.CancelDiscovery();
        }

        try
        {
            context.UnregisterReceiver(this);
        }
        catch { }

        return Task.CompletedTask;
    }

    public override void OnReceive(Context context, Intent intent)
    {
        if (intent.Action != BluetoothDevice.ActionFound)
        {
            return;
        }

        var device = (BluetoothDevice?)intent.GetParcelableExtra(BluetoothDevice.ExtraDevice);

        if (device == null)
        {
            return;
        }

        DeviceDiscovered?.Invoke(new DeviceModel
        {
            Id = device.Address,
            Name = device.Name ?? "Unknown device"
        });
    }
}