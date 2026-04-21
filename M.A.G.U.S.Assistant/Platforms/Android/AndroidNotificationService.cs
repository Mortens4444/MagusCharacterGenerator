using Android.App;
using Android.Content;
using Android.OS;
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

        if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
        {
            var channel = new NotificationChannel(
                ChannelId,
                ChannelName,
                NotificationImportance.Default)
            {
                Description = "General app notifications"
            };

            var manager = (NotificationManager?)global::Android.App.Application.Context.GetSystemService(Context.NotificationService);
            manager?.CreateNotificationChannel(channel);
        }

        initialized = true;
    }

    public void ShowNotification(string title, string message, int notificationId = 1)
    {
        Initialize();

        var builder = new NotificationCompat.Builder(global::Android.App.Application.Context, ChannelId)
            .SetContentTitle(title)
            .SetContentText(message)
            .SetSmallIcon(Resource.Mipmap.appicon)
            .SetPriority((int)NotificationPriority.Default)
            .SetAutoCancel(true);

        var manager = NotificationManagerCompat.From(global::Android.App.Application.Context);
        manager.Notify(notificationId, builder.Build());
    }
}