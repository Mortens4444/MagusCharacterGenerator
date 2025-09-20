using Mtf.LanguageService.MAUI;

namespace M.A.G.U.S.Assistant.Views;

public partial class MarketPage : NotifierPage
{
    public MarketPage()
    {
        InitializeComponent();
        Translator.Translate(this);
    }
}