using CoreBluetooth;
using CoreFoundation;
using Foundation;
using M.A.G.U.S.Assistant.Interfaces.Bluetooth;
using M.A.G.U.S.Assistant.Models.Bluetooth;

namespace M.A.G.U.S.Assistant.Platforms.MacCatalyst;

internal sealed class BluetoothDiscoveryService : CBCentralManagerDelegate, IBluetoothDiscoveryService, IDisposable
{
    private CBCentralManager? manager;

    public event Action<DeviceModel>? DeviceDiscovered;

    public BluetoothDiscoveryService()
    {
        manager = new CBCentralManager(this, DispatchQueue.MainQueue);
    }

    public Task StartDiscoveryAsync(CancellationToken cancellationToken = default)
    {
        manager?.ScanForPeripherals((CBUUID[])null);
        return Task.CompletedTask;
    }

    public Task StopDiscoveryAsync()
    {
        manager?.StopScan();
        return Task.CompletedTask;
    }

    public override void DiscoveredPeripheral(
        CBCentralManager central,
        CBPeripheral peripheral,
        NSDictionary advertisementData,
        NSNumber RSSI)
    {
        DeviceDiscovered?.Invoke(new DeviceModel
        {
            Id = peripheral.Identifier.ToString(),
            Name = peripheral.Name ?? "Unknown device"
        });
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            manager?.StopScan();
            manager?.Dispose();
            manager = null;
        }

        base.Dispose(disposing);
    }
}