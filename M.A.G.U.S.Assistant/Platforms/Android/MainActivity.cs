using Android;
using Android.App;
using Android.Content.PM;
using Android.OS;
using AndroidX.Core.App;
using AndroidX.Core.Content;

namespace M.A.G.U.S.Assistant;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        RequestNotificationPermission();
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
