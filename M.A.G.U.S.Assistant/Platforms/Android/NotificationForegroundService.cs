using Android.App;
using Android.Content;
using Android.OS;
using AndroidX.Core.App;
using AndroidX.Core.Content;
using Mtf.Extensions.Services;
using Mtf.LanguageService.MAUI;
using System.Runtime.Versioning;

namespace M.A.G.U.S.Assistant.Platforms.Android;

[Service(
    Name = "M.A.G.U.S.Assistant.Platforms.Android.NotificationForegroundService",
    Exported = false)]
internal sealed class NotificationForegroundService : Service
{
    private const string ChannelId = "background_notification_service";
    private const string ChannelName = "Background Notification Service";
    private const int ForegroundNotificationId = 5000;

    private CancellationTokenSource? cancellationTokenSource;
    private int notificationId = 6000;

    public override IBinder? OnBind(Intent? intent)
    {
        return null;
    }

    private const double TimerIntervalMinutes = 60;
    private static readonly string[] notifications = [
        "You heard a strange noise. In the Battle menu, you can find out what it was...",
        "You can send your opinion about the game, or what should be improved, to the email address found in the About menu.",
        "If the gods of luck are on your side today, you will soon find out in the Dice menu.",
        "You found the tracks of an unknown creature in the mud. In the Bestiary menu, you can look up what you are facing.",
        "- Stupid dog, what are you snarling at! (Last words)",
        "- Relax, it is just a kobold. How dangerous can it be? (Last words)",
        "- I think it is asleep. I will go over and poke it. (Last words)",
        "- Let us not waste magic on it. I will handle it with a stick. (Last words)",
        "- What trap? I do not see any trap. (Last words)",
        "- I bet this drink is a healing potion. (Last words)",
        "- The necromancer is a person too. Let us talk it out with him. (Last words)",
        "- Come on, statues do not move. (Last words)",
        "- Do not worry, I can swim in armor. (Last words)",
        "- This bridge looks completely stable. (Last words)",
        "- Who is Darton, and why should I be afraid of him? (Last words)",
        "- We do not need a watch. No one comes through here anyway. (Last words)",
        "- I will distract the giant. (Last words)",
        "- According to the map, this way is shorter. (Last words)",
        "- The sound came from inside the wall. I will put my ear to it. (Last words)",
        "- This wolf is too skinny to be a problem. (Last words)",
        "- The orc is just bluffing. (Last words)",
        "- Relax, I know what I am doing. (Last words)",
        "- If you are going to be picky, I will eat it! (Last words)"
    ];

    public override StartCommandResult OnStartCommand(Intent? intent, StartCommandFlags flags, int startId)
    {
        if (intent?.Action == NotificationServiceActions.Stop)
        {
            StopSelf();
            return StartCommandResult.NotSticky;
        }

        // Use OperatingSystem.IsAndroidVersionAtLeast so the platform analyzer recognizes the guard for API 26+.
        if (OperatingSystem.IsAndroidVersionAtLeast(26))
        {
            CreateNotificationChannel();
        }

        var notificationIndex = RandomProvider.GetSecureRandomInt(0, notifications.Length);
        var foregroundNotification = CreateNotification("M.A.G.U.S. Assistant", Lng.Elem(notifications[notificationIndex]));

        if (foregroundNotification is null)
        {
            // If we couldn't create a notification, there's no point in running as a foreground service.
            StopSelf();
            return StartCommandResult.NotSticky;
        }

        // Use a platform API check that the analyzer recognizes to avoid CA1416.
        // Only call the overload that accepts a ForegroundService type when running on Android 34+,
        // because the enum value TypeSpecialUse is only supported on 34.0 and later.
        if (OperatingSystem.IsAndroidVersionAtLeast(34))
        {
            StartForeground(ForegroundNotificationId, foregroundNotification!, global::Android.Content.PM.ForegroundService.TypeSpecialUse);
}
        else
        {
            // For Android versions earlier than 34, use the two-argument overload.
            StartForeground(ForegroundNotificationId, foregroundNotification!);
        }

        StartNotificationLoop();

        return StartCommandResult.Sticky;
    }

    public override void OnDestroy()
    {
        cancellationTokenSource?.Cancel();
        cancellationTokenSource?.Dispose();
        cancellationTokenSource = null;

        base.OnDestroy();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            cancellationTokenSource?.Cancel();
            cancellationTokenSource?.Dispose();
            cancellationTokenSource = null;
        }

        base.Dispose(disposing);
    }

    private void StartNotificationLoop()
    {
        if (cancellationTokenSource is not null)
        {
            return;
        }

        cancellationTokenSource = new CancellationTokenSource();
        var token = cancellationTokenSource.Token;

        _ = Task.Run(async () =>
        {
            using var periodicTimer = new PeriodicTimer(TimeSpan.FromMinutes(TimerIntervalMinutes));

            while (!token.IsCancellationRequested && await periodicTimer.WaitForNextTickAsync(token).ConfigureAwait(false))
            {
                var id = Interlocked.Increment(ref notificationId);

                var notificationIndex = RandomProvider.GetSecureRandomInt(0, notifications.Length);
                ShowNotification("M.A.G.U.S. Assistant", Lng.Elem(notifications[notificationIndex]), id);
            }
        }, token);
    }

    private void ShowNotification(string title, string message, int id)
    {
        if (!CanSendNotifications())
        {
            return;
        }

        var notification = CreateNotification(title, message);
        if (notification is null)
        {
            return;
        }

        var manager = NotificationManagerCompat.From(this);
        if (manager is null)
        {
            return;
        }

        // notification was null-checked above; use null-forgiving to satisfy flow analysis.
        manager.Notify(id, notification!);
    }

    private Notification? CreateNotification(string title, string message)
    {
        // Create the intent and dispose it after creating the PendingIntent to satisfy CA2000.
        using var stopIntent = new Intent(this, typeof(NotificationForegroundService));
        stopIntent.SetAction(NotificationServiceActions.Stop);

        // Build flags conditionally to avoid using PendingIntentFlags.Immutable on API < 23
        var pendingIntentFlags = PendingIntentFlags.UpdateCurrent;
        if (OperatingSystem.IsAndroidVersionAtLeast(23))
        {
            pendingIntentFlags |= PendingIntentFlags.Immutable;
        }

        var stopPendingIntent = PendingIntent.GetService(this, 0, stopIntent, pendingIntentFlags);

        // Use a using on the builder to ensure it is disposed (fixes CA2000).
        using var builder = new NotificationCompat.Builder(this, ChannelId);
        builder.SetContentTitle(title);
        builder.SetContentText(message);
        builder.SetSmallIcon(Resource.Mipmap.appicon);
        builder.SetOngoing(true);
        builder.SetPriority((int)NotificationPriority.Default);

        // Add action only when the PendingIntent is not null to avoid potential null-dereference.
        if (stopPendingIntent is not null)
        {
            builder.AddAction(0, "Leállítás", stopPendingIntent);
        }

        // Build can theoretically return null in some bindings; keep nullable return and let callers handle it.
        return builder.Build();
    }

    [SupportedOSPlatform("android26.0")]
    private void CreateNotificationChannel()
    {
        // Create and dispose the channel after registering it to satisfy CA2000.
        using var channel = new NotificationChannel(
            ChannelId,
            ChannelName,
            NotificationImportance.Default)
        {
            Description = "MAGUS Assistant background notification service"
        };

        var manager = (NotificationManager?)GetSystemService(NotificationService);
        if (manager is null)
        {
            return;
        }

        manager.CreateNotificationChannel(channel);
    }

    private bool CanSendNotifications()
    {
        if (Build.VERSION.SdkInt < BuildVersionCodes.Tiramisu)
        {
            return true;
        }

        // Avoid referencing Manifest.Permission.PostNotifications (annotated for Android 33+)
        // to silence CA1416 while still performing the runtime SDK check above.
        const string postNotificationsPermission = "android.permission.POST_NOTIFICATIONS";

        return ContextCompat.CheckSelfPermission(
            this,
            postNotificationsPermission) == global::Android.Content.PM.Permission.Granted;
    }
}