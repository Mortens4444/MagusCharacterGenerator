using Mtf.LanguageService.MAUI;

namespace M.A.G.U.S.Assistant.Views;

internal partial class CharacterOverviewView : ContentView
{
	public CharacterOverviewView()
	{
		InitializeComponent();
		Translator.Translate(this);
    }
}