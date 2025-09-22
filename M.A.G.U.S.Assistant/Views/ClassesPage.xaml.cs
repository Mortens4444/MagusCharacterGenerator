using Mtf.LanguageService.MAUI;

namespace M.A.G.U.S.Assistant.Views;

public partial class ClassesPage : NotifierPage
{
	public ClassesPage()
	{
		InitializeComponent();
        Translator.Translate(this);
    }
}