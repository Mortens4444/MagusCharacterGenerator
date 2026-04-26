using Android.App;
using Android.Content;
using Android.OS;
using AndroidX.Core.App;
using AndroidX.Core.Content;
using Mtf.LanguageService.MAUI;

namespace M.A.G.U.S.Assistant.Platforms.Android;

internal static class AndroidNotificationHelper
{
    private const string permission = "android.permission.POST_NOTIFICATIONS";

    public const string GeneralChannelId = "general_notifications";
    public const string GeneralChannelName = "General Notifications";
    public const string BackgroundChannelId = "background_notification_service";
    public const string BackgroundChannelName = "Background Notification Service";

    public static void CreateChannel(Context context, string channelId, string channelName, string description)
    {
        if (!OperatingSystem.IsAndroidVersionAtLeast(26))
        {
            return;
        }

        using var channel = new NotificationChannel(
            channelId,
            channelName,
            NotificationImportance.Default)
        {
            Description = description
        };

        var manager = context.GetSystemService(Context.NotificationService) as NotificationManager;
        manager?.CreateNotificationChannel(channel);
    }

    public static Notification? CreateNotification(
        Context context,
        string channelId,
        string title,
        string message,
        bool ongoing = false,
        PendingIntent? actionIntent = null)
    {
        using var builder = new NotificationCompat.Builder(context, channelId);

        builder.SetContentTitle(title);
        builder.SetContentText(message);
        builder.SetSmallIcon(Resource.Mipmap.appicon);
        builder.SetPriority((int)NotificationPriority.Default);
        builder.SetAutoCancel(!ongoing);
        builder.SetOngoing(ongoing);

        if (actionIntent is not null)
        {
            builder.AddAction(0, Lng.Elem("Stop"), actionIntent);
        }

        return builder.Build();
    }

    public static bool CanSendNotifications(Context context)
    {
        if (Build.VERSION.SdkInt < BuildVersionCodes.Tiramisu)
        {
            return true;
        }

        return ContextCompat.CheckSelfPermission(context, permission) == global::Android.Content.PM.Permission.Granted;
    }
}