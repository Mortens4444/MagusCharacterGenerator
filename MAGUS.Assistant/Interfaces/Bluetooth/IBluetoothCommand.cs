using MAGUS.Assistant.Contexts;
using MAGUS.Assistant.Enums;

namespace MAGUS.Assistant.Interfaces.Bluetooth;

internal interface IBluetoothCommand
{
    BluetoothCommandType CommandType { get; }

    Task ExecuteAsync(CommandContext context, string payload);
}
