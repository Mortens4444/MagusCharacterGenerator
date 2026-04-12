using M.A.G.U.S.Assistant.Interfaces.Bluetooth;
using M.A.G.U.S.Assistant.Models.Bluetooth;

namespace M.A.G.U.S.Assistant.Stubs;

internal sealed class StubBluetoothDiscoveryService : IBluetoothDiscoveryService
{
    public event Action<DeviceModel>? DeviceDiscovered;

    public Task<bool> StartDiscoveryAsync(CancellationToken cancellationToken = default) => Task.FromResult(false);

    public void StopDiscovery() { }
}
