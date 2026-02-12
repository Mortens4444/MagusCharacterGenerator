using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using M.A.G.U.S.Assistant.Enums;
using M.A.G.U.S.Assistant.Interfaces;
using M.A.G.U.S.Assistant.Models;
using M.A.G.U.S.Assistant.Services;
using M.A.G.U.S.GameSystem;
using Mtf.LanguageService.MAUI;
using Mtf.Maui.Controls.Messages;
using System.Windows.Input;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class RollFormulaViewModel : BaseViewModel, IDisposable
{
    public event EventHandler<TaskCompletionSource<bool>>? RollRequested;
    public event EventHandler? CloseRequested;

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

        ExecutionMode = rollFormula.DefaultToAuto ? ExecutionMode.Auto : ExecutionMode.UserInput;
        UpdateActionText();
    }

    private void UpdateActionText()
    {
        ActionButtonText = IsAuto ? Lng.Elem("Execute") : Lng.Elem("Submit");
        OnPropertyChanged(nameof(ActionButtonText));
    }

    public IShakeService? ShakeService => shakeService;

    public ICommand ActionCommand => new AsyncRelayCommand(ExecuteActionAsync);

    public ICommand SetAutoCommand => new Command(() => ExecutionMode = ExecutionMode.Auto);

    public ICommand SetManualCommand => new Command(() => ExecutionMode = ExecutionMode.UserInput);
    
    public ICommand CloseCommand => new Command(() =>
    {
        if (!IsResultLocked)
        {
            WeakReferenceMessenger.Default.Send(
                new ShowErrorMessage("Please roll or enter a result first."));
            return;
        }

        CloseRequested?.Invoke(this, EventArgs.Empty);
    });

    public string ActionButtonText { get; private set; }

    public bool IsResultLocked
    {
        get => resultLocked;
        private set
        {
            if (resultLocked == value) return;
            resultLocked = value;
            OnPropertyChanged();
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
            OnPropertyChanged();
            OnPropertyChanged(nameof(IsAuto));
            OnPropertyChanged(nameof(Result));
        }
    }

    private ExecutionMode executionMode;

    public ExecutionMode ExecutionMode
    {
        get => executionMode;
        set
        {
            if (executionMode == value) return;
            executionMode = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(IsAuto));
            UpdateActionText();
        }
    }

    public bool IsAuto => ExecutionMode == ExecutionMode.Auto;

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
            OnPropertyChanged();
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
            OnPropertyChanged();
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
        
        await tcs.Task.ConfigureAwait(true);

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
            });
        }
        else
        {
            var range = diceThrow.GetRange(RollFormula.ThrowType, RollFormula.Modifier, RollFormula.SpecialTraining);
            var ok = Int32.TryParse(UserResultString, out var parsed);
            if (!ok || (parsed < range.Min) || (parsed > range.Max))
            {
                WeakReferenceMessenger.Default.Send(new ShowErrorMessage(String.Format(Lng.Elem("Roll result should be between: {0} - {1}"), range.Min, range.Max)));
            }
            else
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    Result = parsed;
                    IsResultLocked = true;
                });
            }
        }
    }

    private void OnShakeDetected(object? sender, EventArgs e)
    {
        CommandExecutor.ExecuteOnUIThread(TriggerActionFromShake);
    }

    public void Dispose()
    {
        if (shakeService != null)
        {
            shakeService.ShakeDetected -= OnShakeDetected;
        }
    }
}