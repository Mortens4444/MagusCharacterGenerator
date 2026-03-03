using M.A.G.U.S.Assistant.Interfaces;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.Assistant.ViewModels;

internal sealed class RunesViewModel : SearchListViewModel
{
    private readonly IRuneTranslator runeTranslator;

    private string plainText = String.Empty;
    private string runeText = String.Empty;

    private bool isUpdating;

    public RunesViewModel(ISoundPlayer soundPlayer, IRuneTranslator runeTranslator)
        : base(soundPlayer)
    {
        this.runeTranslator = runeTranslator;
        PageTitle = "Runes";
    }

    public string PlainText
    {
        get => plainText;
        set
        {
            if (plainText == value)
            {
                return;
            }

            plainText = value ?? String.Empty;
            OnPropertyChanged();

            if (isUpdating)
            {
                return;
            }

            try
            {
                isUpdating = true;
                RuneText = runeTranslator.ToRunes(plainText);
            }
            finally
            {
                isUpdating = false;
            }
        }
    }

    public string RuneText
    {
        get => runeText;
        set
        {
            if (runeText == value)
            {
                return;
            }

            runeText = value ?? String.Empty;
            OnPropertyChanged();

            if (isUpdating)
            {
                return;
            }

            try
            {
                isUpdating = true;
                PlainText = runeTranslator.ToPlain(runeText);
            }
            finally
            {
                isUpdating = false;
            }
        }
    }
}