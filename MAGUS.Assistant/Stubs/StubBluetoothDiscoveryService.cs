using MAGUS.Assistant.Interfaces.Bluetooth;
using MAGUS.Assistant.Models.Bluetooth;

namespace MAGUS.Assistant.Stubs;

internal sealed class StubBluetoothDiscoveryService : IBluetoothDiscoveryService
{
    public event Action<DeviceModel>? DeviceDiscovered;

    public Task<bool> StartDiscoveryAsync(CancellationToken cancellationToken = default) => Task.FromResult(false);

    public void StopDiscovery() { }
}
