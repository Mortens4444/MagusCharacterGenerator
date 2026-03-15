using M.A.G.U.S.Assistant.Contexts;
using M.A.G.U.S.Assistant.Enums;
using M.A.G.U.S.Assistant.Interfaces.Bluetooth;
using M.A.G.U.S.Assistant.Models.Bluetooth;
using Newtonsoft.Json;

namespace M.A.G.U.S.Assistant.Commands;

internal sealed class SendPsiMessageCommand : IBluetoothCommand
{
    public BluetoothCommandType CommandType => BluetoothCommandType.PsiMessage;

    public Task ExecuteAsync(CommandContext context, string payload)
    {
        var data = JsonConvert.DeserializeObject<ForceCombatData>(payload);
        return Task.CompletedTask;
    }
}
