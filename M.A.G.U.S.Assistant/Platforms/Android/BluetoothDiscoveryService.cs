using Android.Bluetooth;
using Android.Content;
using M.A.G.U.S.Assistant.Interfaces.Bluetooth;
using M.A.G.U.S.Assistant.Models.Bluetooth;

namespace M.A.G.U.S.Assistant.Platforms.Android;

internal sealed class BluetoothDiscoveryService(Context context)
    : BroadcastReceiver, IBluetoothDiscoveryService, IDisposable
{
    private readonly BluetoothAdapter adapter = BluetoothAdapter.DefaultAdapter;
    private readonly Context context = context;

    private bool disposed;

    public event Action<DeviceModel>? DeviceDiscovered;

    public async Task StartDiscoveryAsync(CancellationToken cancellationToken = default)
    {
        if (adapter == null || !adapter.IsEnabled)
        {
            return;
        }

        await StopDiscoveryAsync().ConfigureAwait(false);
        if (adapter.BondedDevices != null)
        {
            foreach (var bonded in adapter.BondedDevices)
            {
                DeviceDiscovered?.Invoke(new DeviceModel
                {
                    Id = bonded.Address!,
                    Name = bonded.Name ?? "Unknown device"
                });
            }
        }

        using (var filter = new IntentFilter(BluetoothDevice.ActionFound))
        {
#if ANDROID33_0_OR_GREATER
            context.RegisterReceiver(this, filter, ReceiverFlags.NotExported);
#elif ANDROID26_0_OR_GREATER
            // For API 26+, use RegisterReceiver with ActivityFlags (no ReceiverFlags)
            context.RegisterReceiver(this, filter, (Android.Content.ActivityFlags)0);
#else
            // For API < 26, use the legacy RegisterReceiver
            context.RegisterReceiver(this, filter);
#endif
        }

        if (adapter.IsDiscovering)
        {
            adapter.CancelDiscovery();
        }

        adapter.StartDiscovery();
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

#if ANDROID33_0_OR_GREATER
        var device = intent.GetParcelableExtra(BluetoothDevice.ExtraDevice, Java.Lang.Class.FromType(typeof(BluetoothDevice))) as BluetoothDevice;
#else
#pragma warning disable CA1416 // Suppress platform compatibility warning for Android < 33
        var device = (BluetoothDevice?)intent.GetParcelableExtra(BluetoothDevice.ExtraDevice);
#pragma warning restore CA1416
#endif
        if (device?.Address == null)
        {
            return;
        }

        DeviceDiscovered?.Invoke(new DeviceModel
        {
            Id = device.Address,
            Name = device.Name ?? "Unknown device"
        });
    }

    protected override void Dispose(bool disposing)
    {
        if (disposed)
        {
            base.Dispose(disposing);
            return;
        }

        disposed = true;

        if (disposing)
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
        }

        base.Dispose(disposing);
    }
}