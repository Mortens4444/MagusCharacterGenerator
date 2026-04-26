#if ANDROID
using Android.Bluetooth;
using Android.Content;
#endif
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using M.A.G.U.S.Assistant.Enums;
using M.A.G.U.S.Assistant.Interfaces;
using M.A.G.U.S.Assistant.Interfaces.Bluetooth;
using M.A.G.U.S.Assistant.Messages;
using M.A.G.U.S.Assistant.Models.Bluetooth;
using Mtf.Extensions.Services;
using Mtf.LanguageService.MAUI;
using Mtf.Maui.Controls.Messages;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class StorytellingViewModel : ObservableObject, IDisposable, IAsyncDisposable
{
    private readonly IBluetoothService bluetooth;
    private readonly INotificationService notificationService;

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
    public IAsyncRelayCommand SendNotificationCommand { get; }

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
                SendNotificationCommand.NotifyCanExecuteChanged();
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
                SendNotificationCommand.NotifyCanExecuteChanged();
            }
        }
    }

    public DeviceModel? SelectedDevice
    {
        get => selectedDevice;
        set => SetProperty(ref selectedDevice, value);
    }

    public StorytellingViewModel(IBluetoothService bluetooth, INotificationService notificationService)
    {
        this.bluetooth = bluetooth;
        this.notificationService = notificationService;

        Unsubscribe();
        bluetooth.DeviceDiscovered += BluetoothDeviceDiscovered;
        bluetooth.MessageReceived += OnMessageReceived;
        bluetooth.ClientDisconnected += OnClientDisconnected;

        StartStoryCommand = new AsyncRelayCommand(StartStoryAsync, CanStartStory);
        ConnectCommand = new AsyncRelayCommand<DeviceModel?>(ConnectAsync);
        //StartCombatCommand = new AsyncRelayCommand(StartCombatAsync);
        //SendPsiCommand = new AsyncRelayCommand(SendPsiAsync);
        SendPrivateMessageCommand = new AsyncRelayCommand(SendPrivateMessageAsync, CanSendPrivateMessage);
        SendNotificationCommand = new AsyncRelayCommand(SendNotificationAsync, CanSendPrivateMessage);

    }

    private void BluetoothDeviceDiscovered(DeviceModel device)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            if (!AvailableDevices.Any(d => d.MacAddress == device.MacAddress))
            {
                AvailableDevices.Add(device);
            }
        });
    }

    public async Task<bool?> StartDiscoveryAsync()
    {
        try
        {
            StatusMessage = Lng.Elem("Searching for devices...");
            return await bluetooth.StartDiscoveryAsync().ConfigureAwait(false);
        }
        catch (Exception ex)
        {
#if ANDROID
            // If the platform reports Bluetooth disabled, try prompting the user to enable it.
            try
            {
                if (ex.Message?.Contains("Bluetooth is disabled") == true)
                {
                    try
                    {
                        // Prefer the current activity when available so the system dialog can return a result.
                        var activity = Platform.CurrentActivity;
                        var ctx = (Context?)activity ?? Android.App.Application.Context;

                        using var enableIntent = new Intent(BluetoothAdapter.ActionRequestEnable);
                        // If starting from a non-activity context, ensure a new task flag is present
                        enableIntent.AddFlags(ActivityFlags.NewTask);
                        ctx.StartActivity(enableIntent);

                        // Let the caller know discovery did not start yet; UI can retry after user enables Bluetooth.
                        return null;
                    }
                    catch (Exception inner)
                    {
                        WeakReferenceMessenger.Default.Send(new ShowErrorMessage(inner));
                    }
                }
                else
                {
                    WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
                }
            }
            catch (Exception) { }
#else
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
#endif

            return false;
        }
    }

    public async Task StopServerAsync()
    {
        try
        {
            await bluetooth.StopServerAsync().ConfigureAwait(true);
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
            await bluetooth.ConnectAsync(device.MacAddress).ConfigureAwait(false);
            await bluetooth.SendAsync(new BluetoothMessage
            {
                CommandType = BluetoothCommandType.RegisterPlayer,
                SenderId = bluetooth.LocalId,
                TargetIds = [],
                //TargetIds = [device.MacAddress],
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

    private Task OnClientDisconnected(string macAddress)
    {
        return MainThread.InvokeOnMainThreadAsync(() =>
        {
            var player = ConnectedPlayers.FirstOrDefault(p => p.Id == macAddress);
            if (player is not null)
            {
                ConnectedPlayers.Remove(player);
            }
        });
    }

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

            case BluetoothCommandType.NotificationMessage:
                HandleNotificationMessage(message);
                break;

            default:
                WeakReferenceMessenger.Default.Send(new ShowInfoMessage("Unknown message arrived", String.Concat(message.CommandType.ToString(), " - ", message.Payload)));
                break;
        }
    }

    private void HandleNotificationMessage(BluetoothMessage message)
    {
        var data = JsonConvert.DeserializeObject<NotificationMessageData>(message.Payload);
        if (data is null || String.IsNullOrWhiteSpace(data.Message))
        {
            return;
        }

        var title = String.IsNullOrWhiteSpace(data.Title) ? "M.A.G.U.S. Assistant" : data.Title;
        var id = RandomProvider.GetSecureRandomInt(Int32.MinValue, Int32.MaxValue);
        notificationService.ShowNotification(title, data.Message, id);
    }

    private static Task HandlePrivateMessage(BluetoothMessage message)
    {
        var data = JsonConvert.DeserializeObject<PrivateMessageData>(message.Payload);
        if (data is null)
        {
            WeakReferenceMessenger.Default.Send(new ShowInfoMessage("Private message", "No message"));
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
            var existingPlayer = ConnectedPlayers.FirstOrDefault(p => p.Id == message.SenderId);
            if (existingPlayer is not null)
            {
                existingPlayer.Name = data.Name;
                return;
            }

            ConnectedPlayers.Add(new PlayerModel
            {
                Id = message.SenderId,
                Name = data.Name
            });
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
            //WeakReferenceMessenger.Default.Send(new ShowInfoMessage($"Sending: {SelectedPlayer.Id}", $"To {SelectedPlayer.Name}: {MessageText}"));
            await bluetooth.SendAsync(new BluetoothMessage
            {
                CommandType = BluetoothCommandType.PrivateMessage,
                SenderId = bluetooth.LocalId,
                //TargetIds = [],
                TargetIds = [SelectedPlayer.Id],
                Payload = JsonConvert.SerializeObject(new PrivateMessageData
                {
                    Text = MessageText
                })
            }).ConfigureAwait(false);

            MessageText = String.Empty;
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage($"{Lng.Elem("Failed to send private message")}: {ex.Message}"));
        }
    }

    private async Task SendNotificationAsync()
    {
        if (SelectedPlayer is null || String.IsNullOrWhiteSpace(MessageText))
        {
            return;
        }

        try
        {
            await bluetooth.SendAsync(new BluetoothMessage
            {
                CommandType = BluetoothCommandType.NotificationMessage,
                SenderId = bluetooth.LocalId,
                TargetIds = [SelectedPlayer.Id],
                Payload = JsonConvert.SerializeObject(new NotificationMessageData
                {
                    Title = "M.A.G.U.S. Assistant",
                    Message = MessageText
                })
            }).ConfigureAwait(false);

            MessageText = String.Empty;
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(
                $"{Lng.Elem("Failed to send notification")}: {ex.Message}"));
        }
    }

    //private async Task StartCombatAsync()
    //{
    //    var selectedEnemies = Enemies
    //        .Where(e => e.IsSelected)
    //        .Select(e => e.Id)
    //        .ToList();

    //    var selectedPlayers = ConnectedPlayers
    //        .Where(p => p.IsSelected)
    //        .Select(p => p.Id)
    //        .ToList();

    //    if (selectedEnemies.Count == 0 || selectedPlayers.Count == 0)
    //    {
    //        return;
    //    }

    //    await bluetooth.SendAsync(new BluetoothMessage
    //    {
    //        CommandType = BluetoothCommandType.ForceCombat,
    //        SenderId = bluetooth.LocalId,
    //        TargetIds = selectedPlayers,
    //        Payload = JsonConvert.SerializeObject(new ForceCombatData
    //        {
    //            EnemyIds = selectedEnemies
    //        })
    //    }).ConfigureAwait(false);
    //}

    //private async Task SendPsiAsync()
    //{
    //    var sender = ConnectedPlayers.FirstOrDefault(p => p.IsSelectedSender);
    //    var target = ConnectedPlayers.FirstOrDefault(p => p.IsSelectedTarget);

    //    if (sender is null || target is null)
    //    {
    //        return;
    //    }

    //    if (sender.Character.Psi == null || sender.Character.PsiPoints <= 0)
    //    {
    //        return;
    //    }

    //    await bluetooth.SendAsync(new BluetoothMessage
    //    {
    //        CommandType = BluetoothCommandType.PsiMessage,
    //        SenderId = sender.Id,
    //        TargetIds = [target.Id],
    //        Payload = JsonConvert.SerializeObject(new SendPsiMessageData
    //        {
    //            Message = "Psi message..."
    //        })
    //    }).ConfigureAwait(false);

    //    //sender.Character.PsiPoints--; TODO
    //}

    public void StopDiscovery()
    {
        bluetooth?.StopDiscovery();
    }

    public async ValueTask DisposeAsync()
    {
        await StopServerAsync().ConfigureAwait(false);
    }

    public void Dispose()
    {
        Unsubscribe();
    }

    private void Unsubscribe()
    {
        bluetooth.DeviceDiscovered -= BluetoothDeviceDiscovered;
        bluetooth.MessageReceived -= OnMessageReceived;
        bluetooth.ClientDisconnected -= OnClientDisconnected;
    }
}