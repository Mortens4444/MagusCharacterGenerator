using Android.App;
using Android.Content;
using AndroidX.Core.App;
using M.A.G.U.S.Assistant.Interfaces;

namespace M.A.G.U.S.Assistant.Platforms.Android;

internal sealed class AndroidNotificationService : INotificationService
{
    private const string ChannelId = "general_notifications";
    private const string ChannelName = "General Notifications";

    private bool initialized;

    public void Initialize()
    {
        if (initialized)
        {
            return;
        }

        var context = global::Android.App.Application.Context;
        if (context == null)
        {
            // Cannot initialize without a context
            return;
        }

        // Use OperatingSystem.IsAndroidVersionAtLeast so the platform compatibility analyzer
        // understands the runtime API check (NotificationChannel requires API 26+).
        if (OperatingSystem.IsAndroidVersionAtLeast(26))
        {
            using var channel = new NotificationChannel(
                ChannelId,
                ChannelName,
                NotificationImportance.Default)
            {
                Description = "General app notifications"
            };

            var manager = context.GetSystemService(Context.NotificationService) as NotificationManager;
            manager?.CreateNotificationChannel(channel);
        }

        initialized = true;
    }

    public void ShowNotification(string title, string message, int notificationId = 1)
    {
        Initialize();

        var context = global::Android.App.Application.Context;
        if (context == null)
        {
            return;
        }

        var manager = NotificationManagerCompat.From(context);
        if (manager == null)
        {
            return;
        }

        // Ensure the builder is disposed even if Build() or Notify() throws.
        using var builder = new NotificationCompat.Builder(context, ChannelId);
        // Methods return the builder but the instance is not null; call them for side-effects.
        builder.SetContentTitle(title);
        builder.SetContentText(message);
        builder.SetSmallIcon(Resource.Mipmap.appicon);
        builder.SetPriority((int)NotificationPriority.Default);
        builder.SetAutoCancel(true);

        var notification = builder.Build();
        if (notification != null)
        {
            manager.Notify(notificationId, notification);
        }
    }

    public void StartBackgroundNotificationService()
    {
        Initialize();

        var context = global::Android.App.Application.Context;
        if (context == null)
        {
            return;
        }

        using var intent = new Intent(context, typeof(NotificationForegroundService));
        intent.SetAction(NotificationServiceActions.Start);

        // Use OperatingSystem.IsAndroidVersionAtLeast so the platform compatibility analyzer
        // understands the runtime API check (StartForegroundService requires API 26+).
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
        if (context == null)
        {
            return;
        }

        using var intent = new Intent(context, typeof(NotificationForegroundService));
        intent.SetAction(NotificationServiceActions.Stop);

        context.StartService(intent);
    }
}