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

    public bool StartDiscovery(CancellationToken cancellationToken = default)
    {
        manager?.ScanForPeripherals((CBUUID[])null);
        return true;
    }

    public void StopDiscovery()
    {
        manager?.StopScan();
    }

    public override void DiscoveredPeripheral(
        CBCentralManager central,
        CBPeripheral peripheral,
        NSDictionary advertisementData,
        NSNumber RSSI)
    {
        DeviceDiscovered?.Invoke(new DeviceModel
        {
            MacAddress = peripheral.Identifier.ToString(),
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