using Android;
using Android.App;
using Android.Content.PM;
using Android.OS;
using AndroidX.Core.App;
using AndroidX.Core.Content;
using MAGUS.Assistant.Services;

namespace MAGUS.Assistant;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        RequestNotificationPermission();
    }

    protected override void OnResume()
    {
        base.OnResume();
        CheckPendingInteractiveEvent();
    }

    // Runs on every resume - covers both a cold start from the notification and the app simply
    // being brought back to the foreground while the background service kept running - without
    // needing to reason about Intent extras or MAUI Shell readiness timing.
    private static void CheckPendingInteractiveEvent()
    {
        try
        {
            var gameEventService = MauiProgram.Services.GetRequiredService<GameEventService>();
            if (!gameEventService.HasPendingInteractiveEvent)
            {
                return;
            }

            MainThread.BeginInvokeOnMainThread(async () =>
            {
                try
                {
                    await gameEventService.ResolvePendingInteractiveEventIfAnyAsync().ConfigureAwait(false);
                }
                catch
                {
                    // best-effort; never let a background event check crash the activity
                }
            });
        }
        catch
        {
            // best-effort; never let a background event check crash the activity
        }
    }

    private void RequestNotificationPermission()
    {
        // Use the runtime platform API so the analyzer knows this callsite
        // is guarded for Android 13 / API 33 and later.
        if (!OperatingSystem.IsAndroidVersionAtLeast(33))
        {
            return;
        }

        if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.PostNotifications) == Permission.Granted)
        {
            return;
        }

        ActivityCompat.RequestPermissions(this, new[] { Manifest.Permission.PostNotifications }, 1001);
    }
}
