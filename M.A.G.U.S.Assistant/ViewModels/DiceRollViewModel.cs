using CommunityToolkit.Mvvm.Messaging;
using M.A.G.U.S.Enums;
using Mtf.LanguageService;
using Mtf.Maui.Controls.Models;
#if ANDROID
using Plugin.Maui.Audio;
#endif
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class DiceRollViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private byte diceCount = 1;
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

    public IEnumerable<DiceType> DiceTypes { get; } = Enum.GetValues<DiceType>().Cast<DiceType>();

    private DiceType selectedDice;
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

    private bool isCustomSelected;
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

    private int customFrom = 1;
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

    private int customTo = 6;
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

    private string resultSummary = String.Empty;
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

    private string resultDetails = String.Empty;
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

    public ICommand RollCommand { get; }

    private readonly Random random = new();
#if ANDROID
    private IAudioPlayer audioPlayer;
#endif
    public DiceRollViewModel()
    {
        RollCommand = new Command(async () => await RollDiceAsync());
        TryLoadSound();
    }

    private void TryLoadSound()
    {
        try
        {

            var assembly = GetType().Assembly;
            var stream = assembly.GetManifestResourceStream("M.A.G.U.S.Assistant.Resources.Raw.dice_roll.wav");
            if (stream != null)
            {
                if (Vibration.Default.IsSupported)
                {
                    Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
                }
#if ANDROID
                audioPlayer = AudioManager.Current.CreatePlayer(stream);
#endif
            }
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex.Message));
        }
    }

    private async Task RollDiceAsync()
    {
        var tcs = new TaskCompletionSource<bool>();

        DiceRollRequested?.Invoke(this, tcs);

        try
        {
            try
            {
#if ANDROID
                audioPlayer.Play();
#endif
            }
            catch (Exception ex)
            {
            }
            await tcs.Task;
        }
        catch (Exception ex)
        {
            WeakReferenceMessenger.Default.Send(new ShowErrorMessage(ex.Message));
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

    public event EventHandler<TaskCompletionSource<bool>> DiceRollRequested;

    private void OnPropertyChanged(string name)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
