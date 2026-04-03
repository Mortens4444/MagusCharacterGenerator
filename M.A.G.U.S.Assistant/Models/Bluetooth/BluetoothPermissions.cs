#if ANDROID

namespace M.A.G.U.S.Assistant.Models.Bluetooth;

public sealed class BluetoothPermissions : Permissions.BasePlatformPermission
{
    public override (string androidPermission, bool isRuntime)[] RequiredPermissions
    {
        get
        {
            var perms = new List<(string, bool)>();

            if (OperatingSystem.IsAndroidVersionAtLeast(31))
            {
                // Android 12+
                perms.Add((Android.Manifest.Permission.BluetoothScan, true));
                perms.Add((Android.Manifest.Permission.BluetoothConnect, true));

                // csak ha tényleg kell:
                // perms.Add((Android.Manifest.Permission.BluetoothAdvertise, true));
            }
            else
            {
                // Android < 12 → Location kell discovery-hez
                perms.Add((Android.Manifest.Permission.AccessFineLocation, true));

                // ezek NEM runtime permissionök!
                perms.Add((Android.Manifest.Permission.Bluetooth, false));
                perms.Add((Android.Manifest.Permission.BluetoothAdmin, false));
            }

            return perms.ToArray();
        }
    }
}
#endif