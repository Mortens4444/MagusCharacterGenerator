//using CommunityToolkit.Mvvm.Messaging;
//using M.A.G.U.S.Assistant.Contexts;
//using M.A.G.U.S.Assistant.Enums;
//using M.A.G.U.S.Assistant.Interfaces.Bluetooth;
//using M.A.G.U.S.Assistant.Models.Bluetooth;
//using Newtonsoft.Json;

//namespace M.A.G.U.S.Assistant.Commands;

//public class RegisterPlayerCommand : IBluetoothCommand
//{
//    BluetoothCommandType IBluetoothCommand.CommandType => BluetoothCommandType.RegisterPlayer;

//    public async Task ExecuteAsync(CommandContext context, string payload)
//    {
//        var data = JsonConvert.DeserializeObject<RegisterPlayerData>(payload);
//        if (data != null)
//        {
//            // Üzenet küldése a ViewModelnek, hogy új játékos csatlakozott
//            WeakReferenceMessenger.Default.Send(new PlayerRegisteredMessage(context.SenderDeviceId, data.Name));
//        }
//    }
//}