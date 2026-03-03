using M.A.G.U.S.Assistant.Contexts;

namespace M.A.G.U.S.Assistant.Interfaces.Bluetooth;

internal interface IBluetoothCommand
{
    string Name { get; }

    Task ExecuteAsync(CommandContext context, string payload);
}
