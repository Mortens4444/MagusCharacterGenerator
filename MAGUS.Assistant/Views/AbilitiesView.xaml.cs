using Mtf.LanguageService.MAUI;

namespace MAGUS.Assistant.Views;

internal sealed partial class AbilitiesView : ContentView
{
	public AbilitiesView()
	{
		InitializeComponent();
        Translator.Translate(this);
    }
}