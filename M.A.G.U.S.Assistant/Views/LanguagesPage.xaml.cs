using Mtf.LanguageService.MAUI;

namespace M.A.G.U.S.Assistant.Views;

public partial class LanguagesPage : NotifierPage
{
	public LanguagesPage()
	{
		InitializeComponent();
		Translator.Translate(this);
	}
}
