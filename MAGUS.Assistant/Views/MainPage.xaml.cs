using MAGUS.Assistant.Services;
using Mtf.LanguageService.MAUI;
using Mtf.LanguageService.MAUI.Views;
using MAGUS.Assistant.ViewModels;

namespace MAGUS.Assistant.Views;

internal sealed partial class MainPage : NotifierPage
{
    private bool firstRun = true;
    private readonly Dictionary<object, string>? originalTextElements;

    public MainPage(MainPageViewModel viewModel) : base(false)
    {
        InitializeComponent();
        BindingContext = viewModel;
        originalTextElements ??= Translator.Translate(this);
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Re-translate every time (not just on first run), so labels like the "Clash" menu
        // item pick up a language change made on the Settings page after the user navigates back.
        if (originalTextElements != null)
        {
            Translator.SetOriginalTexts(originalTextElements);
        }
        _ = Translator.Translate(this);

        if (firstRun)
        {
            firstRun = false;

            // initialize view model and language
            _ = ((MainPageViewModel)BindingContext).InitializeAsync();
            _ = PreloadService.Instance.InitializeAsync();
        }
    }

    protected override void OnDisappearing()
    {
        ((MainPageViewModel)BindingContext).StopNotifications();
    }
}
