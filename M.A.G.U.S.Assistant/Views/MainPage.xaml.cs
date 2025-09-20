using Mtf.LanguageService;
using Mtf.LanguageService.Enums;
using Mtf.LanguageService.MAUI;

namespace M.A.G.U.S.Assistant.Views;

public partial class MainPage : NotifierPage
{
    public MainPage()
    {
        InitializeComponent();
        Lng.DefaultLanguage = Language.Hungarian;
        Translator.Translate(this);
    }
}
