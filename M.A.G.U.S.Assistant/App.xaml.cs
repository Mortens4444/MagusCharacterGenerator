using M.A.G.U.S.Assistant.Interfaces;

namespace M.A.G.U.S.Assistant;

public partial class App : Application
{
    public App(INotificationService notificationService)
    {
        InitializeComponent();
        notificationService?.Initialize();
        UserAppTheme = AppTheme.Dark;
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