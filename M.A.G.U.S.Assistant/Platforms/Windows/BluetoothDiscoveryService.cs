using M.A.G.U.S.Assistant.Interfaces.Bluetooth;
using M.A.G.U.S.Assistant.Models.Bluetooth;
using Windows.Devices.Enumeration;

namespace M.A.G.U.S.Assistant.Platforms.Windows;

internal sealed partial class BluetoothDiscoveryService : IBluetoothDiscoveryService, IDisposable
{
    private const string BluetoothProtocolId = "{e0cbf06c-cd8b-4647-bb8a-263b43f0f974}";

    private readonly Lock syncRoot = new();
    private readonly HashSet<string> discoveredDevices = [];
    private DeviceWatcher? watcher;
    private bool disposed;

    public event Action<DeviceModel>? DeviceDiscovered;

    public Task<bool> StartDiscoveryAsync(CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        lock (syncRoot)
        {
            ObjectDisposedException.ThrowIf(disposed, this);
        }

        StopDiscovery();
        cancellationToken.ThrowIfCancellationRequested();

        //AddPairedDevices(cancellationToken);

        var selector = $"System.Devices.Aep.ProtocolId:=\"{BluetoothProtocolId}\"";

        watcher = DeviceInformation.CreateWatcher(
            selector,
            ["System.Devices.Aep.IsPaired", "System.Devices.Aep.DeviceAddress", "System.ItemNameDisplay"],
            DeviceInformationKind.AssociationEndpoint);

        watcher.Added += OnDeviceAdded;
        watcher.Updated += OnDeviceUpdated;
        watcher.Start();

        return Task.FromResult(true);
    }

    //private void AddPairedDevices(CancellationToken cancellationToken)
    //{
    //    var selector =
    //        $"System.Devices.Aep.ProtocolId:=\"{BluetoothProtocolId}\" AND System.Devices.Aep.IsPaired:=System.StructuredQueryType.Boolean#True";

    //    var devices = DeviceInformation.FindAllAsync(
    //        selector,
    //        ["System.Devices.Aep.IsPaired", "System.Devices.Aep.DeviceAddress", "System.ItemNameDisplay"],
    //        DeviceInformationKind.AssociationEndpoint)
    //        .AsTask()
    //        .GetAwaiter()
    //        .GetResult();

    //    foreach (var device in devices)
    //    {
    //        cancellationToken.ThrowIfCancellationRequested();
    //        PublishDevice(device);
    //    }
    //}

    private void OnDeviceAdded(DeviceWatcher sender, DeviceInformation device)
    {
        lock (syncRoot)
        {
            if (disposed)
            {
                return;
            }
        }

        PublishDevice(device);
    }

    private void OnDeviceUpdated(DeviceWatcher sender, DeviceInformationUpdate deviceUpdate)
    {
        // opcionális: ha akarod, itt újraolvashatod a device-et
        // jelenleg nincs rá szükség
    }

    private void PublishDevice(DeviceInformation device)
    {
        if (String.IsNullOrWhiteSpace(device.Id))
        {
            return;
        }

        lock (syncRoot)
        {
            if (disposed)
            {
                return;
            }

            if (!discoveredDevices.Add(device.Id))
            {
                return;
            }
        }

        DeviceDiscovered?.Invoke(new DeviceModel
        {
            MacAddress = device.Id,
            Name = String.IsNullOrWhiteSpace(device.Name) ? "Unknown device" : device.Name
        });
    }

    public void StopDiscovery()
    {
        lock (syncRoot)
        {
            if (disposed)
            {
                return;
            }

            if (watcher != null)
            {
                try
                {
                    watcher.Added -= OnDeviceAdded;
                    watcher.Updated -= OnDeviceUpdated;

                    if (watcher.Status is DeviceWatcherStatus.Started or DeviceWatcherStatus.EnumerationCompleted)
                    {
                        watcher.Stop();
                    }
                }
                catch
                {
                }

                watcher = null;
            }

            discoveredDevices.Clear();
        }
    }

    public void Dispose()
    {
        lock (syncRoot)
        {
            if (disposed)
            {
                return;
            }

            disposed = true;
        }

        StopDiscovery();
    }
}