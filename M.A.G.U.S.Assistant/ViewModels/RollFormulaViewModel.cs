using CommunityToolkit.Mvvm.Messaging;
using M.A.G.U.S.Assistant.Enums;
using M.A.G.U.S.Assistant.Interfaces;
using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.Assistant.Services;
using M.A.G.U.S.GameSystem;
using Mtf.LanguageService;
using Mtf.Maui.Controls.Models;
using System.ComponentModel;
using System.Windows.Input;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class RollFormulaViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    public event EventHandler<TaskCompletionSource<bool>>? RollRequested;
    public event EventHandler<(int Result, ExecutionMode Mode)>? RollCompleted;

    private readonly ISoundPlayer? soundPlayer;
    private readonly IShakeService? shakeService;
    private readonly DiceThrow diceThrow = new();

    private RollFormula rollFormula;
    private int result;
    private string userResultString = String.Empty;
    private bool resultLocked;

    public RollFormulaViewModel(ISoundPlayer? soundPlayer, IShakeService? shakeService, RollFormula rollFormula)
    {
        this.rollFormula = rollFormula;
        this.soundPlayer = soundPlayer;
        this.shakeService = shakeService;
        if (shakeService != null)
        {
            shakeService.ShakeDetected += OnShakeDetected;
        }

        ActionCommand = new Command(async () => ExecuteActionAsync().ConfigureAwait(false));
        ActionButtonText = rollFormula.DefaultToAuto ? Lng.Elem("Execute") : Lng.Elem("Submit");
    }

    public IShakeService? ShakeService => shakeService;
    public ICommand ActionCommand { get; }
    public string ActionButtonText { get; private set; }

    public bool IsResultLocked
    {
        get => resultLocked;
        private set
        {
            if (resultLocked == value) return;
            resultLocked = value;
            OnPropertyChanged(nameof(IsResultLocked));
            OnPropertyChanged(nameof(IsActionEnabled));
        }
    }

    public bool IsActionEnabled => !IsResultLocked;

    public RollFormula RollFormula
    {
        get => rollFormula;
        set
        {
            if (rollFormula == value)
            {
                return;
            }

            rollFormula = value;
            OnPropertyChanged(nameof(RollFormula));
            OnPropertyChanged(nameof(IsAuto));
            OnPropertyChanged(nameof(Result));
        }
    }

    public bool IsAuto => RollFormula?.DefaultToAuto ?? true;

    public int Result
    {
        get => result;
        private set
        {
            if (result == value)
            {
                return;
            }

            result = value;
            OnPropertyChanged(nameof(Result));
        }
    }

    public string UserResultString
    {
        get => userResultString;
        set
        {
            if (userResultString == value)
            {
                return;
            }

            userResultString = value;
            OnPropertyChanged(nameof(UserResultString));
        }
    }

    public void TriggerActionFromShake()
    {
        if (IsAuto)
        {
            _ = ExecuteActionAsync();
        }
    }

    private async Task ExecuteActionAsync()
    {
        var tcs = new TaskCompletionSource<bool>();
        RollRequested?.Invoke(this, tcs);

        if (soundPlayer != null)
        {
            await soundPlayer.PlayAndVibrateAsync("dice_roll").ConfigureAwait(false);
        }
        
        await tcs.Task.ConfigureAwait(false);
        
        if (IsResultLocked)
        {
            return;
        }

        if (IsAuto)
        {
            var thrown = diceThrow.Throw(RollFormula.ThrowType, RollFormula.Modifier, RollFormula.SpecialTraining);

            MainThread.BeginInvokeOnMainThread(() =>
            {
                Result = thrown;
                IsResultLocked = true;
                RollCompleted?.Invoke(this, (Result, ExecutionMode.Auto));
            });
        }
        else
        {
            var range = diceThrow.GetRange(RollFormula.ThrowType, RollFormula.Modifier, RollFormula.SpecialTraining);
            var ok = Int32.TryParse(UserResultString, out var parsed);
            if (!ok || (parsed < range.Min) || (parsed > range.Max))
            {
                WeakReferenceMessenger.Default.Send(new ShowErrorMessage(String.Format("Roll result should be between: {0} - {1}", range.Min, range.Max)));
            }
            else
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    Result = parsed;
                    IsResultLocked = true;
                    RollCompleted?.Invoke(this, (Result, ExecutionMode.UserInput));
                });
            }
        }
    }

    private void OnShakeDetected(object? sender, EventArgs e)
    {
        CommandExecutor.ExecuteOnUIThread(TriggerActionFromShake);
    }

    private void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}