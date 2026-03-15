using Mtf.LanguageService.MAUI;

namespace M.A.G.U.S.Assistant.Views;

internal partial class CharacterDetailsView : ContentView
{
	public CharacterDetailsView()
	{
		InitializeComponent();
        Translator.Translate(this);
    }
}