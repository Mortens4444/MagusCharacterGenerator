using M.A.G.U.S.Assistant.Interfaces.Bluetooth;
using M.A.G.U.S.Assistant.Models.Bluetooth;

namespace M.A.G.U.S.Assistant.Stubs;

internal sealed class StubBluetoothDiscoveryService : IBluetoothDiscoveryService
{
    public event Action<DeviceModel>? DeviceDiscovered;

    public Task StartDiscoveryAsync(CancellationToken cancellationToken = default) => Task.CompletedTask;

    public Task StopDiscoveryAsync() => Task.CompletedTask;
}
