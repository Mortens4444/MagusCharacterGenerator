using Mtf.LanguageService;
using Plugin.Maui.Audio;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace MagusAssistant.ViewModels;

public class DiceRollViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    public ObservableCollection<string> DiceOptions { get; } = new ObservableCollection<string>
    {
        "K4", "K6", "K8", "K10", "K12", "K20", "K100",
        "2K6", "3K6", "2K10", "3K8"
    };

    private string selectedDice = "K6";
    public string SelectedDice
    {
        get => selectedDice;
        set
        {
            if (selectedDice == value) return;
            selectedDice = value;
            OnPropertyChanged(nameof(SelectedDice));
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
#if ANDROID
                audioPlayer = AudioManager.Current.CreatePlayer(stream);
#endif
            }
        }
        catch (Exception ex)
        {
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
        catch
        {
        }

        ResultSummary = String.Empty;
        ResultDetails = String.Empty;

        var pattern = new Regex(@"^(?:(\d+)?[kK])(\d+)$");
        var m = pattern.Match(SelectedDice ?? String.Empty);
        int count = 1;
        int sides = 6;
        if (m.Success)
        {
            if (!String.IsNullOrEmpty(m.Groups[1].Value))
            {
                Int32.TryParse(m.Groups[1].Value, out count);
            }
            Int32.TryParse(m.Groups[2].Value, out sides);
        }

        var sbDetails = new StringBuilder();
        var total = 0;
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
