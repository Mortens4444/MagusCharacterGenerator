using MAGUS.Assistant.Interfaces;
using MAGUS.Assistant.Services;
using Mtf.LanguageService;

namespace MAGUS.Assistant;

public partial class App : Application
{
    internal App(INotificationService notificationService, SettingsService settingsService)
    {
        InitializeComponent();
        notificationService?.Initialize();
        UserAppTheme = AppTheme.Dark;

        try
        {
            // Must happen before any page is constructed, so the very first
            // Translator.Translate(this) call on any page uses the persisted language
            // instead of the language service's built-in default.
            Lng.DefaultLanguage = settingsService.GetCurrentLanguageAsync().GetAwaiter().GetResult();
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