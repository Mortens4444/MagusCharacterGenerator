//using CommunityToolkit.Mvvm.Messaging;
//using MAGUS.Assistant.Contexts;
//using MAGUS.Assistant.Enums;
//using MAGUS.Assistant.Interfaces.Bluetooth;
//using MAGUS.Assistant.Models.Bluetooth;
//using Newtonsoft.Json;

//namespace MAGUS.Assistant.Commands;

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