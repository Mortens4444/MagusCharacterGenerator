using Android.Content;
using AndroidX.Core.App;
using M.A.G.U.S.Assistant.Interfaces;

namespace M.A.G.U.S.Assistant.Platforms.Android;

internal sealed class AndroidNotificationService : INotificationService
{
    private bool initialized;

    public void Initialize()
    {
        if (initialized)
        {
            return;
        }

        var context = global::Android.App.Application.Context;
        if (context is null)
        {
            return;
        }

        AndroidNotificationHelper.CreateChannel(context, AndroidNotificationHelper.GeneralChannelId, AndroidNotificationHelper.GeneralChannelName, "General app notifications");

        initialized = true;
    }

    public void ShowNotification(string title, string message, int notificationId = 1)
    {
        Initialize();

        var context = global::Android.App.Application.Context;
        if (context is null || !AndroidNotificationHelper.CanSendNotifications(context))
        {
            return;
        }

        var notification = AndroidNotificationHelper.CreateNotification(context, AndroidNotificationHelper.GeneralChannelId, title, message);
        if (notification is null)
        {
            return;
        }

        NotificationManagerCompat.From(context).Notify(notificationId, notification);
    }

    public void StartBackgroundNotificationService()
    {
        Initialize();

        var context = global::Android.App.Application.Context;
        if (context is null)
        {
            return;
        }

        using var intent = new Intent(context, typeof(NotificationForegroundService));
        intent.SetAction(NotificationServiceActions.Start);

        if (OperatingSystem.IsAndroidVersionAtLeast(26))
        {
            context.StartForegroundService(intent);
        }
        else
        {
            context.StartService(intent);
        }
    }

    public void StopBackgroundNotificationService()
    {
        var context = global::Android.App.Application.Context;
        if (context is null)
        {
            return;
        }

        using var intent = new Intent(context, typeof(NotificationForegroundService));
        intent.SetAction(NotificationServiceActions.Stop);

        context.StartService(intent);
    }
}