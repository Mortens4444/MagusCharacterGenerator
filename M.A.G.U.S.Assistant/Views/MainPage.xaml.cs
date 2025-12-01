using M.A.G.U.S.Assistant.Services;
using Mtf.LanguageService;
using Mtf.LanguageService.MAUI;

namespace M.A.G.U.S.Assistant.Views;

internal partial class MainPage : NotifierPage
{
    private readonly SettingsService settingsService;
    private Dictionary<object, string>? originalTextElements;

    public MainPage(SettingsService settingsService)
    {
        this.settingsService = settingsService;
        InitializeComponent();
        if (originalTextElements == null)
        {
            originalTextElements = Translator.Translate(this);
        }
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (originalTextElements != null)
        {
            Translator.SetOriginalTexts(originalTextElements);
        }
        Lng.DefaultLanguage = settingsService.GetCurrentLanguageAsync().GetAwaiter().GetResult();
        _ = Translator.Translate(this);
    }
}
