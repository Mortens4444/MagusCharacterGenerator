using M.A.G.U.S.Assistant.Messages;

namespace M.A.G.U.S.Assistant.Interfaces.Bluetooth;

internal interface IBluetoothService
{
    string LocalId { get; }

    Task StartServerAsync();
    Task ConnectAsync(string deviceId);

    Task SendAsync(BluetoothMessage message);

    event Func<BluetoothMessage, Task>? MessageReceived;
}
