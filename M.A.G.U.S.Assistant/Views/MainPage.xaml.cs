using M.A.G.U.S.Assistant.Services;
using Mtf.LanguageService.MAUI;
using Mtf.LanguageService.MAUI.Views;

namespace M.A.G.U.S.Assistant.Views;

internal partial class MainPage : NotifierPage
{
    private bool firstRun = true;
    private readonly SettingsService settingsService;
    private readonly Dictionary<object, string>? originalTextElements;

    public MainPage(SettingsService settingsService) : base(false)
    {
        this.settingsService = settingsService;
        InitializeComponent();
        originalTextElements ??= Translator.Translate(this);
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (firstRun)
        {
            firstRun = false;

            if (originalTextElements != null)
            {
                Translator.SetOriginalTexts(originalTextElements);
            }
            Lng.DefaultLanguage = settingsService.GetCurrentLanguageAsync().GetAwaiter().GetResult();
            _ = PreloadService.Instance.InitializeAsync();
            _ = Translator.Translate(this);
        }
    }
}
