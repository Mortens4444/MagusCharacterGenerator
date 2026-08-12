using Mtf.LanguageService.MAUI;

namespace MAGUS.Assistant.Views;

internal sealed partial class HealthView : ContentView
{
	public HealthView()
	{
		InitializeComponent();
        Translator.Translate(this);
    }
}