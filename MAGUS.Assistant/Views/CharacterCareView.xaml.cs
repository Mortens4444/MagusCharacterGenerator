using Mtf.LanguageService.MAUI;

namespace MAGUS.Assistant.Views;

internal sealed partial class CharacterCareView : ContentView
{
    public CharacterCareView()
    {
        InitializeComponent();
        Translator.Translate(this);
    }
}
