using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using M.A.G.U.S.Assistant.Interfaces.Bluetooth;
using M.A.G.U.S.Assistant.Messages;
using M.A.G.U.S.Assistant.Models.Bluetooth;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class StorytellingViewModel : ObservableObject
{
    private readonly IBluetoothService bluetooth;

    public ObservableCollection<DeviceModel> AvailableDevices { get; } = [];
    public ObservableCollection<PlayerModel> ConnectedPlayers { get; } = [];
    public ObservableCollection<EnemyModel> Enemies { get; } = [];

    public IAsyncRelayCommand StartStoryCommand { get; }
    public IAsyncRelayCommand<DeviceModel> ConnectCommand { get; }
    public IAsyncRelayCommand StartCombatCommand { get; }
    public IAsyncRelayCommand SendPsiCommand { get; }

    public StorytellingViewModel(IBluetoothService bluetooth)
    {
        this.bluetooth = bluetooth;

        StartStoryCommand = new AsyncRelayCommand(StartStoryAsync);
        ConnectCommand = new AsyncRelayCommand<DeviceModel>(ConnectAsync);
        StartCombatCommand = new AsyncRelayCommand(StartCombatAsync);
        SendPsiCommand = new AsyncRelayCommand(SendPsiAsync);
    }

    private Task StartStoryAsync() => bluetooth.StartServerAsync();

    private Task ConnectAsync(DeviceModel device) => bluetooth.ConnectAsync(device.Id);

    private async Task StartCombatAsync()
    {
        var selectedEnemies = Enemies
            .Where(e => e.IsSelected)
            .Select(e => e.Id)
            .ToList();

        var selectedPlayers = ConnectedPlayers
            .Where(p => p.IsSelected)
            .Select(p => p.Id)
            .ToList();

        if (selectedEnemies.Count == 0 || selectedPlayers.Count == 0)
            return;

        await bluetooth.SendAsync(new BluetoothMessage
        {
            CommandType = "ForceCombat",
            SenderId = bluetooth.LocalId,
            TargetIds = selectedPlayers,
            Payload = JsonConvert.SerializeObject(new ForceCombatData
            {
                EnemyIds = selectedEnemies
            })
        }).ConfigureAwait(false);
    }

    private async Task SendPsiAsync()
    {
        var sender = ConnectedPlayers.FirstOrDefault(p => p.IsSelectedSender);
        var target = ConnectedPlayers.FirstOrDefault(p => p.IsSelectedTarget);

        if (sender is null || target is null)
            return;

        if (sender.Character.Psi == null || sender.Character.PsiPoints <= 0)
            return;

        await bluetooth.SendAsync(new BluetoothMessage
        {
            CommandType = "PsiMessage",
            SenderId = sender.Id,
            TargetIds = [target.Id],
            Payload = JsonConvert.SerializeObject(new SendPsiMessageData
            {
                Message = "Psi message..."
            })
        }).ConfigureAwait(false);

        //sender.Character.PsiPoints--; TODO
    }
}
