using Mtf.LanguageService.MAUI;

namespace M.A.G.U.S.Assistant.Views;

public partial class RunesPage : NotifierPage
{
	public RunesPage()
	{
		InitializeComponent();
        Translator.Translate(this);
    }
}