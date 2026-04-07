using M.A.G.U.S.Assistant.Interfaces.Bluetooth;

namespace M.A.G.U.S.Assistant.Contexts;

internal sealed class CommandContext
{
    public string LocalDeviceId { get; init; } = String.Empty;

    public IBluetoothService BluetoothService { get; init; } = null!;

    public string SenderMacAddress { get; init; } = String.Empty;
}
