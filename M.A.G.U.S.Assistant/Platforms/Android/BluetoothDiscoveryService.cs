using Android.Bluetooth;
using Android.Content;
using M.A.G.U.S.Assistant.Interfaces.Bluetooth;
using M.A.G.U.S.Assistant.Models.Bluetooth;

namespace M.A.G.U.S.Assistant.Platforms.Android;

internal sealed class BluetoothDiscoveryService(Context context)
    : BroadcastReceiver, IBluetoothDiscoveryService, IDisposable
{
    private readonly BluetoothAdapter adapter = BluetoothAdapter.DefaultAdapter ?? throw new NotSupportedException("Bluetooth not supported.");
    private readonly Context context = context;
    private readonly Lock syncRoot = new();

    private bool disposed;
    private bool isRegistered;

    public event Action<DeviceModel>? DeviceDiscovered;

    public Task<bool> StartDiscoveryAsync(CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        lock (syncRoot)
        {
            ObjectDisposedException.ThrowIf(disposed, this);
        }

        if (!adapter.IsEnabled)
        {
            throw new InvalidOperationException("Bluetooth is disabled.");
        }

        StopDiscovery();
        cancellationToken.ThrowIfCancellationRequested();

        if (adapter.BondedDevices != null)
        {
            foreach (var bonded in adapter.BondedDevices)
            {
                cancellationToken.ThrowIfCancellationRequested();
                DeviceDiscovered?.Invoke(new DeviceModel
                {
                    MacAddress = bonded.Address!,
                    Name = bonded.Name ?? "Unknown device"
                });
            }
        }

        using (var filter = new IntentFilter(BluetoothDevice.ActionFound))
        {
            lock (syncRoot)
            {
                ObjectDisposedException.ThrowIf(disposed, this);

                // Use runtime checks so the platform analyzer knows these calls are guarded
                if (OperatingSystem.IsAndroidVersionAtLeast(33))
                {
                    // API 33+ overload that accepts ReceiverFlags
                    context.RegisterReceiver(this, filter, ReceiverFlags.NotExported);
                }
                else if (OperatingSystem.IsAndroidVersionAtLeast(26))
                {
                    // API 26+ overload that accepts ActivityFlags
#if ANDROID26_0_OR_GREATER                       
                    context.RegisterReceiver(this, filter, (global::Android.Content.ActivityFlags)0);
#endif
                }
                else
                {
                    // Legacy overload for older Android versions
                    context.RegisterReceiver(this, filter);
                }

                isRegistered = true;
            }
        }
        
        if (adapter.IsDiscovering)
        {
            adapter.CancelDiscovery();
        }

        cancellationToken.ThrowIfCancellationRequested();
        return Task.FromResult(adapter.StartDiscovery());
    }

    public void StopDiscovery()
    {
        lock (syncRoot)
        {
            if (disposed)
            {
                return;
            }

            if (adapter.IsDiscovering)
            {
                adapter.CancelDiscovery();
            }

            if (isRegistered)
            {
                try
                {
                    context.UnregisterReceiver(this);
                }
                catch { }

                isRegistered = false;
            }
        }
    }

    public override void OnReceive(Context context, Intent intent)
    {
        lock (syncRoot)
        {
            if (disposed)
            {
                return;
            }
        }

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
            MacAddress = device.Address,
            Name = device.Name ?? "Unknown device"
        });
    }

    protected override void Dispose(bool disposing)
    {
        lock (syncRoot)
        {
            if (disposed)
            {
                return;
            }

            disposed = true;

            if (disposing)
            {
                if (adapter.IsDiscovering)
                {
                    adapter.CancelDiscovery();
                }

                if (isRegistered)
                {
                    try
                    {
                        context.UnregisterReceiver(this);
                    }
                    catch { }

                    isRegistered = false;
                }
            }
        }

        base.Dispose(disposing);
    }
}