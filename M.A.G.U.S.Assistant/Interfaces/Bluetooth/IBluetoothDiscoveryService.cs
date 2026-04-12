using M.A.G.U.S.Assistant.Models.Bluetooth;

namespace M.A.G.U.S.Assistant.Interfaces.Bluetooth;

internal interface IBluetoothDiscoveryService
{
    event Action<DeviceModel> DeviceDiscovered;

    Task<bool> StartDiscoveryAsync(CancellationToken cancellationToken = default);

    void StopDiscovery();
}
