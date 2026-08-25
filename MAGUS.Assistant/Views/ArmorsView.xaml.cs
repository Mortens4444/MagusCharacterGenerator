using Mtf.LanguageService.MAUI;

namespace MAGUS.Assistant.Views;

internal sealed partial class ArmorsView : ContentView
{
	public ArmorsView()
	{
		InitializeComponent();
        Translator.Translate(this);
    }
}