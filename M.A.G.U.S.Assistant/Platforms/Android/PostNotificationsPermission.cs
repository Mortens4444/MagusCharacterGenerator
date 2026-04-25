using Android.OS;

namespace M.A.G.U.S.Assistant.Platforms.Android;

internal sealed class PostNotificationsPermission : Permissions.BasePlatformPermission
{
    public override (string androidPermission, bool isRuntime)[] RequiredPermissions
    {
        get
        {
            if (Build.VERSION.SdkInt < BuildVersionCodes.Tiramisu)
            {
                return [];
            }

            // Use the literal permission string to avoid referencing an API symbol
            // that is only available on Android 33+ (prevents CA1416).
            return [("android.permission.POST_NOTIFICATIONS", true)];
        }
    }
}