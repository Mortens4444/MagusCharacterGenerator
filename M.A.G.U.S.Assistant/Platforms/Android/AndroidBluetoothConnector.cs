using Android.Bluetooth;
using Java.Util;
using M.A.G.U.S.Assistant.Interfaces.Bluetooth;

namespace M.A.G.U.S.Assistant.Platforms.Android;

internal class AndroidBluetoothConnector : IBluetoothConnector
{
    private readonly BluetoothAdapter adapter;
    public static readonly UUID ServiceUuid = UUID.FromString("2EE056EE-5939-4EC4-8593-BC606EE1BF9E");

    public AndroidBluetoothConnector()
    {
        adapter = BluetoothAdapter.DefaultAdapter ?? throw new NotSupportedException("Bluetooth not supported");
    }

    public async Task<IBluetoothConnection> ConnectToAsync(string deviceId, CancellationToken ct)
    {
        // Example (pseudo):
        var device = adapter.GetRemoteDevice(deviceId) ?? throw new ArgumentException($"No device found for address: {deviceId}", nameof(deviceId));
        var socket = device.CreateRfcommSocketToServiceRecord(ServiceUuid);
        adapter.CancelDiscovery();
        if (socket == null)
        {
            throw new InvalidOperationException("Could not create Bluetooth socket");
        }
        await socket.ConnectAsync().ConfigureAwait(false);
        return new AndroidBluetoothConnection(socket);
    }
}