using Android.App;
using Android.Content;
using Android.OS;
using AndroidX.Core.App;
using MAGUS.Assistant.Services;
using Mtf.LanguageService;
using System.Runtime.Versioning;

namespace MAGUS.Assistant.Platforms.Android;

[Service(
    Name = "MAGUS.Assistant.Platforms.Android.NotificationForegroundService",
    Exported = false)]
internal sealed class NotificationForegroundService : Service
{
    private const int ForegroundNotificationId = 5000;

    private CancellationTokenSource? cancellationTokenSource;
    private int notificationId = 6000;

    public override IBinder? OnBind(Intent? intent)
    {
        return null;
    }

    private const double TimerIntervalMinutes = 60;

    public override StartCommandResult OnStartCommand(Intent? intent, StartCommandFlags flags, int startId)
    {
        if (intent?.Action == NotificationServiceActions.Stop)
        {
            StopSelf();
            return StartCommandResult.NotSticky;
        }

        if (OperatingSystem.IsAndroidVersionAtLeast(26))
        {
            CreateNotificationChannel();
        }

        // Kept flavor-only and synchronous here: Android requires StartForeground to be called
        // promptly, so the real (DB-backed) GameEventService roll only happens on the recurring
        // timer below, which has no such time budget constraint.
        using var foregroundNotification = CreateNotification("MAGUS Assistant", Lng.Elem(GameEventService.PickFlavorOnlyMessage()), ongoing: true);

        if (foregroundNotification is null)
        {
            StopSelf();
            return StartCommandResult.NotSticky;
        }

        if (OperatingSystem.IsAndroidVersionAtLeast(34))
        {
            StartForeground(ForegroundNotificationId, foregroundNotification, global::Android.Content.PM.ForegroundService.TypeSpecialUse);
        }
        else
        {
            StartForeground(ForegroundNotificationId, foregroundNotification);
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
                await ShowRolledEventNotificationAsync(id).ConfigureAwait(false);
            }
        }, token);
    }

    private async Task ShowRolledEventNotificationAsync(int id)
    {
        string title;
        string message;

        try
        {
            var gameEventService = MauiProgram.Services.GetRequiredService<GameEventService>();
            (title, message) = await gameEventService.RollAndApplyAsync().ConfigureAwait(false);
        }
        catch (Exception)
        {
            title = "MAGUS Assistant";
            message = Lng.Elem(GameEventService.PickFlavorOnlyMessage());
        }

        ShowNotification(title, message, id);
    }

    private void ShowNotification(string title, string message, int id)
    {
        if (!AndroidNotificationHelper.CanSendNotifications(this))
        {
            return;
        }

        // Not ongoing: each rolled event (ambush, item stolen, ...) is its own discrete, dismissable
        // notification, not a status the app is continuously reporting - unlike the persistent
        // "service is running" notification (id 5000, see OnStartCommand), which does need ongoing:
        // true. Marking every one of these ongoing was making some OEM notification shades collapse
        // them into a single always-latest entry, silently discarding earlier events' text (an
        // ambush/theft notification could get replaced by the next hourly tick's flavor text before
        // ever being read).
        using var notification = CreateNotification(title, message, ongoing: false);
        if (notification is null)
        {
            return;
        }

        NotificationManagerCompat.From(this).Notify(id, notification);
    }

    private Notification? CreateNotification(string title, string message, bool ongoing)
    {
        using var stopIntent = new Intent(this, typeof(NotificationForegroundService));
        stopIntent.SetAction(NotificationServiceActions.Stop);

        var pendingIntentFlags = PendingIntentFlags.UpdateCurrent;
        if (OperatingSystem.IsAndroidVersionAtLeast(23))
        {
            pendingIntentFlags |= PendingIntentFlags.Immutable;
        }

        var stopPendingIntent = PendingIntent.GetService(this, 0, stopIntent, pendingIntentFlags);

        using var contentIntent = new Intent(this, typeof(MainActivity));
        contentIntent.SetFlags(ActivityFlags.SingleTop | ActivityFlags.ReorderToFront);
        var contentPendingIntent = PendingIntent.GetActivity(this, 0, contentIntent, pendingIntentFlags);

        return AndroidNotificationHelper.CreateNotification(this, AndroidNotificationHelper.BackgroundChannelId, title, message, ongoing: ongoing, actionIntent: stopPendingIntent, contentIntent: contentPendingIntent);
    }

    [SupportedOSPlatform("android26.0")]
    private void CreateNotificationChannel()
    {
        AndroidNotificationHelper.CreateChannel(this, AndroidNotificationHelper.BackgroundChannelId,
            AndroidNotificationHelper.BackgroundChannelName, "MAGUS Assistant background notification service");
    }
}