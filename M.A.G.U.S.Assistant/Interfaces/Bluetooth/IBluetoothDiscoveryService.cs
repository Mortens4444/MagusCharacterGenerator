using M.A.G.U.S.Assistant.Models.Bluetooth;

namespace M.A.G.U.S.Assistant.Interfaces.Bluetooth;

internal interface IBluetoothDiscoveryService
{
    event Action<DeviceModel> DeviceDiscovered;

    Task StartDiscoveryAsync(CancellationToken cancellationToken = default);

    Task StopDiscoveryAsync();
}
