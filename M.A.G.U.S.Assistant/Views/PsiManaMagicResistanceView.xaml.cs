using Mtf.LanguageService.MAUI;

namespace M.A.G.U.S.Assistant.Views;

internal sealed partial class PsiManaMagicResistanceView : ContentView
{
	public PsiManaMagicResistanceView()
	{
		InitializeComponent();
		Translator.Translate(this);
    }
}