using Mtf.LanguageService.MAUI;

namespace M.A.G.U.S.Assistant.Views;

public partial class MapPage : NotifierPage
{
	public MapPage()
    {
        InitializeComponent();
        Translator.Translate(this);
    }
}