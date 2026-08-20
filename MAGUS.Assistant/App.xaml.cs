using MAGUS.Assistant.Interfaces;
using Mtf.LanguageService;

namespace MAGUS.Assistant;

public partial class App : Application
{
    // Must stay public: MAUI's DI container (MauiApplication.OnCreate -> GetRequiredService<IApplication>)
    // only considers public constructors via reflection, so App can't be constructed at all if this
    // is internal - which is also why the parameter below is an interface (ILanguageSettingsService)
    // rather than the concrete, internal SettingsService: a public constructor of a public class can't
    // take a less-accessible parameter type (CS0051).
    public App(INotificationService notificationService, ILanguageSettingsService languageSettingsService)
    {
        InitializeComponent();
        notificationService?.Initialize();
        UserAppTheme = AppTheme.Dark;

        try
        {
            // Must happen before any page is constructed, so the very first
            // Translator.Translate(this) call on any page uses the persisted language
            // instead of the language service's built-in default.
            Lng.DefaultLanguage = languageSettingsService.GetCurrentLanguageAsync().GetAwaiter().GetResult();
        }
        catch
        {
            // ignore - keep the language service's built-in default
        }
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        var window = new Window(new AppShell());

#if WINDOWS
    window.HandlerChanged += (_, _) =>
    {
        if (window.Handler?.PlatformView is not Microsoft.UI.Xaml.Window native)
        {
            return;
        }

        var service = MauiProgram.Services.GetRequiredService<IWindowStateService>();
        service.Restore(window);
        service.Attach(window);
    };
#endif

        return window;
    }
}