using M.A.G.U.S.Assistant.Messages;
using M.A.G.U.S.Assistant.Models.Bluetooth;

namespace M.A.G.U.S.Assistant.Interfaces.Bluetooth;

internal interface IBluetoothService
{
    string LocalId { get; }

    Task StartServerAsync();

    Task StopServerAsync();

    Task<bool> StartDiscoveryAsync();

    Task ConnectAsync(string macAddress);

    Task SendAsync(BluetoothMessage message);

    event Action<DeviceModel> DeviceDiscovered;

    event Func<BluetoothMessage, Task>? MessageReceived;
}
