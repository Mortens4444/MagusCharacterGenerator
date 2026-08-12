using Mtf.LanguageService.MAUI;

namespace MAGUS.Assistant.Views;

internal sealed partial class CharacterDetailsView : ContentView
{
	public CharacterDetailsView()
	{
		InitializeComponent();
        Translator.Translate(this);
    }
}