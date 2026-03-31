using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using M.A.G.U.S.Assistant.Enums;
using M.A.G.U.S.Assistant.Interfaces.Bluetooth;
using M.A.G.U.S.Assistant.Messages;
using M.A.G.U.S.Assistant.Models.Bluetooth;
using Mtf.LanguageService.MAUI;
using Mtf.Maui.Controls.Messages;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class StorytellingViewModel : ObservableObject, IDisposable
{
    private readonly IBluetoothService bluetooth;
    private PlayerModel? selectedPlayer;
    private DeviceModel? selectedDevice;
    private String statusMessage = Lng.Elem("Server not started");
    private bool serverRunning;
    private String messageText = String.Empty;

    public ObservableCollection<DeviceModel> AvailableDevices { get; } = [];
    public ObservableCollection<PlayerModel> ConnectedPlayers { get; } = [];
    public ObservableCollection<EnemyModel> Enemies { get; } = [];

    public IAsyncRelayCommand StartStoryCommand { get; }
    public IAsyncRelayCommand<DeviceModel?> ConnectCommand { get; }
    public IAsyncRelayCommand StartCombatCommand { get; }
    public IAsyncRelayCommand SendPsiCommand { get; }
    public IAsyncRelayCommand SendPrivateMessageCommand { get; }

    public bool ServerRunning
    {
        get => serverRunning;
        set
        {
            if (SetProperty(ref serverRunning, value))
            {
                StartStoryCommand.NotifyCanExecuteChanged();
            }
        }
    }

    public String MessageText
    {
        get => messageText;
        set
        {
            if (SetProperty(ref messageText, value))
            {
                SendPrivateMessageCommand.NotifyCanExecuteChanged();
            }
        }
    }

    public String StatusMessage
    {
        get => statusMessage;
        set => SetProperty(ref statusMessage, value);
    }

    public PlayerModel? SelectedPlayer
    {
        get => selectedPlayer;
        set
        {
            if (SetProperty(ref selectedPlayer, value))
            {
                SendPrivateMessageCommand.NotifyCanExecuteChanged();
            }
        }
    }

    public DeviceModel? SelectedDevice
    {
        get => selectedDevice;
        set => SetProperty(ref selectedDevice, value);
    }

    public StorytellingViewModel(IBluetoothService bluetooth)
    {
        this.bluetooth = bluetooth;

        bluetooth.DeviceDiscovered += Bluetooth_DeviceDiscovered;
        bluetooth.MessageReceived += OnMessageReceived;
        //bluetooth.PeerDisconnected += OnPeerDisconnected;

        StartStoryCommand = new AsyncRelayCommand(StartStoryAsync, CanStartStory);
        ConnectCommand = new AsyncRelayCommand<DeviceModel?>(ConnectAsync);
        StartCombatCommand = new AsyncRelayCommand(StartCombatAsync);
        SendPsiCommand = new AsyncRelayCommand(SendPsiAsync);
        SendPrivateMessageCommand = new AsyncRelayCommand(SendPrivateMessageAsync, CanSendPrivateMessage);
    }

    private void Bluetooth_DeviceDiscovered(DeviceModel device)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            if (!AvailableDevices.Any(d => d.Id == device.Id))
            {
                AvailableDevices.Add(device);
            }
        });
    }

    public Task StartDiscoveryAsync()
    {
        StatusMessage = Lng.Elem("Searching for devices...");
        return bluetooth.StartDiscoveryAsync();
    }

    public async Task StopServerAsync()
    {
        try
        {
            await bluetooth.StopServerAsync().ConfigureAwait(false);
            ServerRunning = false;
            StatusMessage = Lng.Elem("Bluetooth server stopped");
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
        }
    }

    private async Task StartStoryAsync()
    {
        try
        {
            StatusMessage = Lng.Elem("Starting Bluetooth server...");
            await bluetooth.StartServerAsync().ConfigureAwait(false);
            ServerRunning = true;
            StatusMessage = Lng.Elem("Bluetooth server started");
        }
        catch (Exception ex)
        {
            StatusMessage = ex.Message;
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
        }
    }

    private async Task ConnectAsync(DeviceModel? device)
    {
        if (device is null)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage("Device not found"));
            return;
        }

        try
        {
            await bluetooth.ConnectAsync(device.Id).ConfigureAwait(false);
            await bluetooth.SendAsync(new BluetoothMessage
            {
                CommandType = BluetoothCommandType.RegisterPlayer,
                SenderId = bluetooth.LocalId,
                TargetIds = [],
                //TargetIds = [device.Id],
                Payload = JsonConvert.SerializeObject(new RegisterPlayerData
                {
                    Name = DeviceInfo.Name
                })
            }).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
        }
    }

    private bool CanStartStory() => !ServerRunning;

    private bool CanSendPrivateMessage()
    {
        return SelectedPlayer is not null && !String.IsNullOrWhiteSpace(MessageText);
    }

    //private void OnPeerDisconnected(object? sender, BluetoothPeerEventArgs e)
    //{
    //    MainThread.BeginInvokeOnMainThread(() =>
    //    {
    //        var player = ConnectedPlayers.FirstOrDefault(p => p.Id == e.PeerId);
    //        if (player is not null)
    //        {
    //            ConnectedPlayers.Remove(player);
    //        }
    //    });
    //}

    private async Task OnMessageReceived(BluetoothMessage message)
    {
        switch (message.CommandType)
        {
            case BluetoothCommandType.RegisterPlayer:
                await HandleRegisterPlayer(message).ConfigureAwait(false);
                break;

            case BluetoothCommandType.PrivateMessage:
                await HandlePrivateMessage(message).ConfigureAwait(false);
                break;

            default:
                WeakReferenceMessenger.Default.Send(new ShowInfoMessage("Unknown message arrived", String.Concat(message.CommandType.ToString(), " - ", message.Payload)));
                break;
        }
    }

    private static Task HandlePrivateMessage(BluetoothMessage message)
    {
        var data = JsonConvert.DeserializeObject<PrivateMessageData>(message.Payload);
        if (data is null)
        {
            return Task.CompletedTask;
        }

        WeakReferenceMessenger.Default.Send(new ShowInfoMessage("Private message", data.Text));
        return Task.CompletedTask;
    }

    private Task HandleRegisterPlayer(BluetoothMessage message)
    {
        var data = JsonConvert.DeserializeObject<RegisterPlayerData>(message.Payload);
        if (data is null)
        {
            return Task.CompletedTask;
        }

        MainThread.BeginInvokeOnMainThread(() =>
        {
            if (ConnectedPlayers.Any(p => p.Id == message.SenderId))
            {
                return;
            }

            ConnectedPlayers.Add(new PlayerModel
            {
                Id = message.SenderId,
                Name = data.Name
            });

            WeakReferenceMessenger.Default.Send(new ShowInfoMessage(Lng.Elem("Player connected"), String.Concat(message.SenderId)));
        });

        return Task.CompletedTask;
    }

    private async Task SendPrivateMessageAsync()
    {
        if (SelectedPlayer is null || String.IsNullOrWhiteSpace(MessageText))
        {
            return;
        }

        try
        {
            await bluetooth.SendAsync(new BluetoothMessage
            {
                CommandType = BluetoothCommandType.PrivateMessage,
                SenderId = bluetooth.LocalId,
                TargetIds = [SelectedPlayer.Id],
                Payload = JsonConvert.SerializeObject(new PrivateMessageData
                {
                    Text = MessageText
                })
            }).ConfigureAwait(false);

            WeakReferenceMessenger.Default.Send(new ShowInfoMessage(Lng.Elem("Private message"), String.Concat(Lng.Elem("Message sent successfully"), " - ", SelectedPlayer.Id)));
            MessageText = String.Empty;
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage($"{Lng.Elem("Failed to send private message")}: {ex.Message}"));
        }
    }

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
        {
            return;
        }

        await bluetooth.SendAsync(new BluetoothMessage
        {
            CommandType = BluetoothCommandType.ForceCombat,
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
        {
            return;
        }

        if (sender.Character.Psi == null || sender.Character.PsiPoints <= 0)
        {
            return;
        }

        await bluetooth.SendAsync(new BluetoothMessage
        {
            CommandType = BluetoothCommandType.PsiMessage,
            SenderId = sender.Id,
            TargetIds = [target.Id],
            Payload = JsonConvert.SerializeObject(new SendPsiMessageData
            {
                Message = "Psi message..."
            })
        }).ConfigureAwait(false);

        //sender.Character.PsiPoints--; TODO
    }

    public void Dispose()
    {
        bluetooth.DeviceDiscovered -= Bluetooth_DeviceDiscovered;
        bluetooth.MessageReceived -= OnMessageReceived;
        //bluetooth.PeerDisconnected -= OnPeerDisconnected;

        _ = StopServerAsync();
    }
}