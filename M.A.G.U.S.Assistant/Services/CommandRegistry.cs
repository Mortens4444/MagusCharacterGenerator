using M.A.G.U.S.Assistant.Interfaces.Bluetooth;

namespace M.A.G.U.S.Assistant.Services;

internal sealed class CommandRegistry
{
    private readonly Dictionary<string, IBluetoothCommand> commands = new();

    public void Register(IBluetoothCommand command) => commands[command.Name] = command;

    public bool TryGet(string name, out IBluetoothCommand command) => commands.TryGetValue(name, out command!);
}
