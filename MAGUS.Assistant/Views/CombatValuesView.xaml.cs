using Mtf.LanguageService.MAUI;

namespace MAGUS.Assistant.Views;

internal sealed partial class CombatValuesView : ContentView
{
	public CombatValuesView()
	{
		InitializeComponent();
        Translator.Translate(this);
    }
}