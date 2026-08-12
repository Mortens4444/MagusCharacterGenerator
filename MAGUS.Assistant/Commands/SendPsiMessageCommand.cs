using MAGUS.Assistant.Contexts;
using MAGUS.Assistant.Enums;
using MAGUS.Assistant.Interfaces.Bluetooth;
using MAGUS.Assistant.Models.Bluetooth;
using Newtonsoft.Json;

namespace MAGUS.Assistant.Commands;

internal sealed class SendPsiMessageCommand : IBluetoothCommand
{
    public BluetoothCommandType CommandType => BluetoothCommandType.PsiMessage;

    public Task ExecuteAsync(CommandContext context, string payload)
    {
        var data = JsonConvert.DeserializeObject<ForceCombatData>(payload);
        return Task.CompletedTask;
    }
}
