using Mtf.LanguageService.MAUI;

namespace MAGUS.Assistant.Views;

internal sealed partial class PsiManaMagicResistanceView : ContentView
{
	public PsiManaMagicResistanceView()
	{
		InitializeComponent();
		Translator.Translate(this);
    }
}