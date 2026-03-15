using M.A.G.U.S.Assistant.Enums;
using M.A.G.U.S.Assistant.Interfaces.Bluetooth;

namespace M.A.G.U.S.Assistant.Services;

internal sealed class CommandRegistry
{
    private readonly Dictionary<BluetoothCommandType, IBluetoothCommand> commands = [];

    public void Register(IBluetoothCommand command) => commands[command.CommandType] = command;

    public bool TryGet(BluetoothCommandType name, out IBluetoothCommand command) => commands.TryGetValue(name, out command!);
}
