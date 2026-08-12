using Mtf.LanguageService.MAUI;

namespace MAGUS.Assistant.Views;

internal sealed partial class CharacterOverviewView : ContentView
{
	public CharacterOverviewView()
	{
		InitializeComponent();
		Translator.Translate(this);
    }
}