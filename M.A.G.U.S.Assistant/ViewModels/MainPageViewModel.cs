using M.A.G.U.S.Assistant.Interfaces;
#if ANDROID
using M.A.G.U.S.Assistant.Platforms.Android;
#endif
using M.A.G.U.S.Assistant.Services;
using Mtf.LanguageService.Enums;

namespace M.A.G.U.S.Assistant.ViewModels;

internal class MainPageViewModel : BaseViewModel
{
    private readonly SettingsService settingsService;

    private Language currentLanguage;
    private readonly INotificationService notificationService;

    public MainPageViewModel(SettingsService settingsService, INotificationService notificationService)
    {
        this.settingsService = settingsService;
        this.notificationService = notificationService;
    }

    public Language CurrentLanguage
    {
        get => currentLanguage;
        private set => SetProperty(ref currentLanguage, value);
    }

    public async Task InitializeAsync()
    {
        try
        {
            var lang = await settingsService.GetCurrentLanguageAsync().ConfigureAwait(false);
            CurrentLanguage = lang;

#if ANDROID
            var status = await Permissions.CheckStatusAsync<PostNotificationsPermission>().ConfigureAwait(false);

            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<PostNotificationsPermission>().ConfigureAwait(false);
            }

            if (status == PermissionStatus.Granted)
            {
                notificationService.StartBackgroundNotificationService();
            }
#else
            notificationService.StartBackgroundNotificationService();
#endif
        }
        catch
        {
            // ignore
        }
    }

    public void StopNotifications()
    {
        notificationService.StopBackgroundNotificationService();
    }
}
