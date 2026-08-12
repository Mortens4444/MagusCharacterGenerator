using MAGUS.Assistant.Messages;
using MAGUS.Assistant.Models.Bluetooth;

namespace MAGUS.Assistant.Interfaces.Bluetooth;

internal interface IBluetoothService
{
    string LocalId { get; }

    Task StartServerAsync();

    Task StopServerAsync();

    Task<bool> StartDiscoveryAsync();

    void StopDiscovery();

    Task ConnectAsync(string macAddress);

    Task SendAsync(BluetoothMessage message);

    event Action<DeviceModel> DeviceDiscovered;

    event Func<string, Task>? ClientDisconnected;

    event Func<BluetoothMessage, Task>? MessageReceived;
}
