using MAGUS.Assistant.Interfaces.Bluetooth;

namespace MAGUS.Assistant.Contexts;

internal sealed class CommandContext
{
    public string LocalDeviceId { get; init; } = String.Empty;

    public IBluetoothService BluetoothService { get; init; } = null!;

    public string SenderMacAddress { get; init; } = String.Empty;
}
