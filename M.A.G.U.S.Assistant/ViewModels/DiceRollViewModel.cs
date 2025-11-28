using CommunityToolkit.Mvvm.Messaging;
using M.A.G.U.S.Assistant.Interfaces;
using M.A.G.U.S.Enums;
using Mtf.LanguageService;
using Mtf.Maui.Controls.Models;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class DiceRollViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    private readonly ISoundPlayer soundPlayer;
    private readonly Random random = new();
    private DiceType selectedDice = DiceType.D100;
    private int customFrom = 1;
    private bool isCustomSelected;
    private byte diceCount = 1;
    private int customTo = 6;
    private string resultSummary = String.Empty;
    private string resultDetails = String.Empty;

    public DiceRollViewModel(ISoundPlayer soundPlayer)
    {
        this.soundPlayer = soundPlayer ?? throw new ArgumentNullException(nameof(soundPlayer));
        RollCommand = new Command(() =>
        {
            _ = RollDiceAsync().ConfigureAwait(false);
        });
    }

    public event EventHandler<TaskCompletionSource<bool>>? DiceRollRequested;

    public ICommand RollCommand { get; }

    public IEnumerable<DiceType> DiceTypes { get; } = Enum.GetValues<DiceType>().Cast<DiceType>();

    public byte DiceCount
    {
        get => diceCount;
        set
        {
            if (diceCount == value)
            {
                return;
            }

            diceCount = value;
            OnPropertyChanged(nameof(DiceCount));
        }
    }

    public DiceType SelectedDice
    {
        get => selectedDice;
        set
        {
            if (selectedDice == value)
            {
                return;
            }

            selectedDice = value;
            IsCustomSelected = selectedDice == DiceType.Custom;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedDice)));
        }
    }

    public bool IsCustomSelected
    {
        get => isCustomSelected;
        private set
        {
            if (isCustomSelected == value)
            {
                return;
            }

            isCustomSelected = value;
            OnPropertyChanged(nameof(IsCustomSelected));
        }
    }

    public int CustomFrom
    {
        get => customFrom;
        set
        {
            if (customFrom == value)
            {
                return;
            }

            customFrom = Math.Max(1, value);
            OnPropertyChanged(nameof(CustomFrom));
        }
    }

    public int CustomTo
    {
        get => customTo;
        set
        {
            if (customTo == value)
            {
                return;
            }

            customTo = Math.Max(1, value);
            OnPropertyChanged(nameof(CustomTo));
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

    private async Task RollDiceAsync()
    {
        var tcs = new TaskCompletionSource<bool>();
        DiceRollRequested?.Invoke(this, tcs);

        try
        {
            if (Vibration.Default.IsSupported)
            {
                Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
            }
            await soundPlayer.PlayAsync(new Models.SoundItem
            {
                ResourceId = "M.A.G.U.S.Assistant.Resources.Raw.dice_roll.mp3"
            }, 1).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex));
        }

        ResultSummary = String.Empty;
        ResultDetails = String.Empty;

        var pattern = new Regex(@"^(?:(\d+)?[dD])(\d+)$");
        var m = pattern.Match($"{SelectedDice}");
        int count = DiceCount;
        int sides = 6;
        var sbDetails = new StringBuilder();
        var total = 0;

        if (SelectedDice == DiceType.Custom)
        {
            var from = CustomFrom;
            var to = CustomTo;
            if (from <= 0)
            {
                from = 1;
            }

            if (to <= 0)
            {
                to = 1;
            }

            if (from > to)
            {
                (from, to) = (to, from);
            }

            sides = to;
            for (var i = 0; i < count; i++)
            {
                var roll = random.Next(from, to + 1);
                total += roll;
                sbDetails.AppendFormat($"{Lng.Elem("Dice roll")} {i + 1}: {roll}{Environment.NewLine}");
            }

            ResultSummary = total.ToString();
            ResultDetails = sbDetails.ToString();
            return;
        }

        if (m.Success)
        {
            if (!String.IsNullOrEmpty(m.Groups[1].Value))
            {
                Int32.TryParse(m.Groups[1].Value, out count);
            }
            Int32.TryParse(m.Groups[2].Value, out sides);
        }

        for (var i = 0; i < count; i++)
        {
            var roll = random.Next(1, sides + 1);
            total += roll;
            sbDetails.AppendFormat($"{Lng.Elem("Dice roll")} {i + 1}: {roll}{Environment.NewLine}");
        }

        ResultSummary = total.ToString();
        ResultDetails = sbDetails.ToString();
    }

    private void OnPropertyChanged(string name)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
