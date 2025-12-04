using CommunityToolkit.Mvvm.Messaging;
using M.A.G.U.S.Assistant.Enums;
using M.A.G.U.S.Assistant.Interfaces;
using M.A.G.U.S.Assistant.Services;
using Mtf.LanguageService;
using Mtf.Maui.Controls.Models;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class RollFormulaViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    public event EventHandler<TaskCompletionSource<bool>>? RollRequested;
    public event EventHandler<(short Result, ExecutionMode Mode)>? RollCompleted;

    private readonly Random random = new();
    private readonly ISoundPlayer soundPlayer;
    private readonly IShakeService shakeService;

    private string formula;
    private short diceModifier;
    private bool isUserInputMode;
    private string userModifierString = String.Empty;
    private string resultSummary = String.Empty;
    private string resultDetails = String.Empty;

    public RollFormulaViewModel(ISoundPlayer soundPlayer, IShakeService shakeService, string formula, short diceModifier = 0, bool defaultToAuto = true)
    {
        this.soundPlayer = soundPlayer ?? throw new ArgumentNullException(nameof(soundPlayer));
        this.shakeService = shakeService ?? throw new ArgumentNullException(nameof(shakeService));
        shakeService.ShakeDetected += OnShakeDetected;

        Formula = formula;
        DiceModifier = diceModifier;
        IsUserInputMode = !defaultToAuto;

        ActionCommand = new Command(
            () => ExecuteActionAsync().ConfigureAwait(false).GetAwaiter().GetResult()
        );

        ActionButtonText = IsUserInputMode ? "Submit" : "Execute";
    }

    public IShakeService ShakeService => shakeService;
    public ICommand ActionCommand { get; }
    public string ActionButtonText { get; private set; }

    public string Formula
    {
        get => formula;
        set
        {
            if (formula == value)
            {
                return;
            }

            formula = value;
            OnPropertyChanged(nameof(Formula));
        }
    }

    public short DiceModifier
    {
        get => diceModifier;
        private set
        {
            if (diceModifier == value)
            {
                return;
            }

            diceModifier = value;
            OnPropertyChanged(nameof(DiceModifier));
        }
    }

    public bool IsUserInputMode
    {
        get => isUserInputMode;
        set
        {
            if (isUserInputMode == value)
            {
                return;
            }

            isUserInputMode = value;
            ActionButtonText = isUserInputMode ? "Submit" : "Execute";
            OnPropertyChanged(nameof(IsUserInputMode));
            OnPropertyChanged(nameof(ActionButtonText));
        }
    }

    public string UserModifierString
    {
        get => userModifierString;
        set
        {
            if (userModifierString == value)
            {
                return;
            }

            userModifierString = value;
            OnPropertyChanged(nameof(UserModifierString));
        }
    }

    public string ResultSummary
    {
        get => resultSummary;
        set
        {
            if (resultSummary == value)
            {
                return;
            }

            resultSummary = value;
            OnPropertyChanged(nameof(ResultSummary));
        }
    }

    public string ResultDetails
    {
        get => resultDetails;
        set
        {
            if (resultDetails == value)
            {
                return;
            }

            resultDetails = value;
            OnPropertyChanged(nameof(ResultDetails));
        }
    }

    public void TriggerActionFromShake()
    {
        if (IsUserInputMode)
        {
            _ = ExecuteActionAsync();
        }
    }

    private async Task ExecuteActionAsync()
    {
        var tcs = new TaskCompletionSource<bool>();
        RollRequested?.Invoke(this, tcs);

        try
        {
            if (Vibration.Default.IsSupported)
            {
                Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(150));
            }

            await soundPlayer.PlayAsync("dice_roll").ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
        }

        ResultSummary = String.Empty;
        ResultDetails = String.Empty;

        if (IsUserInputMode)
        {
            if (!short.TryParse(UserModifierString, out var userVal))
            {
                ResultDetails = Lng.Elem("Invalid modifier");
                return;
            }

            DiceModifier = userVal;
            // just return the modifier as result (user provided)
            ResultSummary = DiceModifier.ToString();
            ResultDetails = Lng.Elem("User provided modifier");
            RollCompleted?.Invoke(this, (DiceModifier, ExecutionMode.UserInput));
            return;
        }

        // Auto mode => parse formula and compute
        var (count, sides, times) = ParseFormula(Formula);
        var sb = new StringBuilder();
        var grandTotal = 0;

        for (var t = 0; t < times; t++)
        {
            var total = 0;
            for (var i = 0; i < count; i++)
            {
                var roll = random.Next(1, sides + 1);
                total += roll;
                sb.AppendLine($"{Lng.Elem("Roll")} {i + 1} (t{t + 1}): {roll}");
            }

            total += DiceModifier;
            sb.AppendLine($"{Lng.Elem("Modifier")}: {DiceModifier}");
            sb.AppendLine($"{Lng.Elem("Subtotal")}: {total}");
            grandTotal += total;
        }

        ResultSummary = grandTotal.ToString();
        ResultDetails = sb.ToString();

        RollCompleted?.Invoke(this, ((short)grandTotal, ExecutionMode.Auto));
    }

    private (int Count, int Sides, int Times) ParseFormula(string f)
    {
        // Accept patterns like "3K6_2_Times", "_3K6_2_Times" or "3K6"
        if (String.IsNullOrWhiteSpace(f))
        {
            return (1, 6, 1);
        }

        var pattern = new Regex(@"_?(\d+)[dD](\d+)(?:_(\d+)_Times)?", RegexOptions.IgnoreCase);
        var m = pattern.Match(f);
        if (!m.Success)
        {
            // fallback: try to parse digits
            return (1, 6, 1);
        }

        var count = 1;
        var sides = 6;
        var times = 1;

        if (!String.IsNullOrEmpty(m.Groups[1].Value))
        {
            Int32.TryParse(m.Groups[1].Value, out count);
        }

        if (!String.IsNullOrEmpty(m.Groups[2].Value))
        {
            Int32.TryParse(m.Groups[2].Value, out sides);
        }

        if (!String.IsNullOrEmpty(m.Groups[3].Value))
        {
            Int32.TryParse(m.Groups[3].Value, out times);
        }

        return (Math.Max(1, count), Math.Max(1, sides), Math.Max(1, times));
    }

    private void OnShakeDetected(object? sender, EventArgs e)
    {
        CommandExecutor.ExecuteOnUIThread(TriggerActionFromShake);
    }

    private void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}