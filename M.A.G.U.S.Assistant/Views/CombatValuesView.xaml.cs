using Mtf.LanguageService.MAUI;

namespace M.A.G.U.S.Assistant.Views;

internal partial class CombatValuesView : ContentView
{
	public CombatValuesView()
	{
		InitializeComponent();
        Translator.Translate(this);
    }
}