using Android.Bluetooth;
using Java.Util;
using M.A.G.U.S.Assistant.Interfaces.Bluetooth;

namespace M.A.G.U.S.Assistant.Platforms.Android;

internal sealed class AndroidBluetoothConnector : IBluetoothConnector
{
    private readonly BluetoothAdapter adapter;
    public static readonly UUID ServiceUuid = UUID.FromString("2EE056EE-5939-4EC4-8593-BC606EE1BF9E");

    public AndroidBluetoothConnector()
    {
        adapter = BluetoothAdapter.DefaultAdapter ?? throw new NotSupportedException("Bluetooth not supported.");
    }

    public async Task<IBluetoothConnection> ConnectToAsync(string deviceId)
    {
        if (String.IsNullOrWhiteSpace(deviceId))
        {
            throw new ArgumentException("Device ID cannot be null or whitespace.", nameof(deviceId));
        }
        if (!adapter.IsEnabled)
        {
            throw new InvalidOperationException("Bluetooth is disabled.");
        }

        BluetoothSocket? socket = null;
        try
        {
            var device = adapter.GetRemoteDevice(deviceId) ?? throw new ArgumentException($"No device found for address: {deviceId}", nameof(deviceId));
            socket = device.CreateRfcommSocketToServiceRecord(ServiceUuid) ?? throw new InvalidOperationException("Could not create Bluetooth socket."); ;
            adapter.CancelDiscovery();
            await socket.ConnectAsync().ConfigureAwait(false);
            return new AndroidBluetoothConnection(socket);
        }
        catch
        {
            try
            {
                socket?.Close();
            }
            catch { }
            try
            {
                socket?.Dispose();
            }
            catch { }

            throw;
        }
    }
}