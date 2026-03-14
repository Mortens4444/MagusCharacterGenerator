using M.A.G.U.S.Assistant.Interfaces.Bluetooth;
using M.A.G.U.S.Assistant.Models.Bluetooth;
using Windows.Devices.Bluetooth;
using Windows.Devices.Enumeration;

namespace M.A.G.U.S.Assistant.Platforms.Windows;

internal sealed class BluetoothDiscoveryService : IBluetoothDiscoveryService
{
    private DeviceWatcher? watcher;

    public event Action<DeviceModel>? DeviceDiscovered;

    public Task StartDiscoveryAsync(CancellationToken cancellationToken = default)
    {
        var selector = "System.Devices.Aep.ProtocolId:=\"{e0cbf06c-cd8b-4647-bb8a-263b43f0f974}\"";

        watcher = DeviceInformation.CreateWatcher(selector);

        watcher.Added += (_, device) =>
        {
            DeviceDiscovered?.Invoke(new DeviceModel
            {
                Id = device.Id,
                Name = device.Name
            });
        };

        watcher.Start();

        return Task.CompletedTask;
    }

    //public Task StartDiscoveryAsync(CancellationToken cancellationToken = default)
    //{
    //    watcher = DeviceInformation.CreateWatcher(
    //        BluetoothLEDevice.GetDeviceSelector());

    //    watcher.Added += (_, device) =>
    //    {
    //        DeviceDiscovered?.Invoke(new DeviceModel
    //        {
    //            Id = device.Id,
    //            Name = device.Name
    //        });
    //    };

    //    watcher.Start();

    //    return Task.CompletedTask;
    //}

    public Task StopDiscoveryAsync()
    {
        watcher?.Stop();
        watcher = null;
        return Task.CompletedTask;
    }
}