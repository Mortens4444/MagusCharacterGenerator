using MAGUS.Assistant.Models.Bluetooth;

namespace MAGUS.Assistant.Interfaces.Bluetooth;

internal interface IBluetoothDiscoveryService
{
    event Action<DeviceModel> DeviceDiscovered;

    Task<bool> StartDiscoveryAsync(CancellationToken cancellationToken = default);

    void StopDiscovery();
}
