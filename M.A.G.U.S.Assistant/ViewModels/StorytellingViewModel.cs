using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using M.A.G.U.S.Assistant.Interfaces.Bluetooth;
using M.A.G.U.S.Assistant.Messages;
using M.A.G.U.S.Assistant.Models.Bluetooth;
using Mtf.Maui.Controls.Messages;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class StorytellingViewModel : ObservableObject
{
    private readonly IBluetoothService bluetooth;
    private PlayerModel? selectedPlayer;
    private DeviceModel? selectedDevice;
    private String statusMessage = "Server not started";

    public ObservableCollection<DeviceModel> AvailableDevices { get; } = [];
    public ObservableCollection<PlayerModel> ConnectedPlayers { get; } = [];
    public ObservableCollection<EnemyModel> Enemies { get; } = [];

    public IAsyncRelayCommand StartStoryCommand { get; }
    public IAsyncRelayCommand<DeviceModel> ConnectCommand { get; }
    public IAsyncRelayCommand StartCombatCommand { get; }
    public IAsyncRelayCommand SendPsiCommand { get; }

    public String StatusMessage
    {
        get => statusMessage;
        set => SetProperty(ref statusMessage, value);
    }

    public PlayerModel? SelectedPlayer
    {
        get => selectedPlayer;
        set => SetProperty(ref selectedPlayer, value);
    }

    public DeviceModel? SelectedDevice
    {
        get => selectedDevice;
        set => SetProperty(ref selectedDevice, value);
    }

    public StorytellingViewModel(IBluetoothService bluetooth)
    {
        this.bluetooth = bluetooth;

        StartStoryCommand = new AsyncRelayCommand(StartStoryAsync);
        ConnectCommand = new AsyncRelayCommand<DeviceModel>(ConnectAsync);
        StartCombatCommand = new AsyncRelayCommand(StartCombatAsync);
        SendPsiCommand = new AsyncRelayCommand(SendPsiAsync);
    }

    private async Task StartStoryAsync()
    {
        try
        {
            StatusMessage = "Starting Bluetooth server...";
            await bluetooth.StartServerAsync();
            StatusMessage = "Bluetooth server started";
        }
        catch (Exception ex)
        {
            StatusMessage = ex.Message;
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
        }
    }

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
