namespace M.A.G.U.S.Assistant.Models.Bluetooth;

#if ANDROID
public class BluetoothPermissions : Permissions.BasePlatformPermission
{
    public override (string androidPermission, bool isRuntime)[] RequiredPermissions =>
    [
        (Android.Manifest.Permission.BluetoothScan, true),
        (Android.Manifest.Permission.BluetoothConnect, true),
        (Android.Manifest.Permission.BluetoothAdvertise, true),
        (Android.Manifest.Permission.AccessFineLocation, true)
    ];
}
#endif