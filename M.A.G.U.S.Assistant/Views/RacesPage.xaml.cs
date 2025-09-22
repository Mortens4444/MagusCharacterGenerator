using Mtf.LanguageService.MAUI;

namespace M.A.G.U.S.Assistant.Views;

public partial class RacesPage : NotifierPage
{
    public RacesPage()
    {
        InitializeComponent();
        Translator.Translate(this);
    }
}