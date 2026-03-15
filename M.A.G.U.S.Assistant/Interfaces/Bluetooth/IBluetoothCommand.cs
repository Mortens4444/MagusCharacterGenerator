using M.A.G.U.S.Assistant.Contexts;
using M.A.G.U.S.Assistant.Enums;

namespace M.A.G.U.S.Assistant.Interfaces.Bluetooth;

internal interface IBluetoothCommand
{
    BluetoothCommandType CommandType { get; }

    Task ExecuteAsync(CommandContext context, string payload);
}
