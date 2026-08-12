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

        if (firstRun)
        {
            firstRun = false;

            if (originalTextElements != null)
            {
                Translator.SetOriginalTexts(originalTextElements);
            }

            // initialize view model and language
            _ = ((MainPageViewModel)BindingContext).InitializeAsync();
            _ = PreloadService.Instance.InitializeAsync();
            _ = Translator.Translate(this);
        }
    }

    protected override void OnDisappearing()
    {
        ((MainPageViewModel)BindingContext).StopNotifications();
    }
}
