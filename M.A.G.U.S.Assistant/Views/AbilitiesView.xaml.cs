using Mtf.LanguageService.MAUI;

namespace M.A.G.U.S.Assistant.Views;

internal partial class AbilitiesView : ContentView
{
	public AbilitiesView()
	{
		InitializeComponent();
        Translator.Translate(this);
    }
}