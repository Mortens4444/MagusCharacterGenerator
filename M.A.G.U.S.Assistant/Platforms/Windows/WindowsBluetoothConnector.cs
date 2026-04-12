using M.A.G.U.S.Assistant.Interfaces.Bluetooth;
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.Rfcomm;
using Windows.Devices.Enumeration;
using Windows.Networking.Sockets;

namespace M.A.G.U.S.Assistant.Platforms.Windows;

internal sealed class WindowsBluetoothConnector : IBluetoothConnector
{
    private static readonly RfcommServiceId ServiceId = RfcommServiceId.FromUuid(new Guid(Constants.ServiceGuid));

    public async Task<IBluetoothConnection> ConnectToAsync(string deviceId)
    {
        if (String.IsNullOrWhiteSpace(deviceId))
        {
            throw new ArgumentException("Device ID cannot be null or whitespace.", nameof(deviceId));
        }

        var bluetoothDevice = await BluetoothDevice.FromIdAsync(deviceId).AsTask().ConfigureAwait(false)
            ?? throw new InvalidOperationException($"Bluetooth device not found for '{deviceId}'.");

        try
        {
            var access = await bluetoothDevice.RequestAccessAsync().AsTask().ConfigureAwait(false);
            if (access != DeviceAccessStatus.Allowed)
            {
                throw new UnauthorizedAccessException($"Bluetooth access denied: {access}");
            }

            var result = await bluetoothDevice
                .GetRfcommServicesForIdAsync(ServiceId, BluetoothCacheMode.Uncached)
                .AsTask()
                .ConfigureAwait(false);

            if (result.Error != BluetoothError.Success)
            {
                throw new InvalidOperationException($"RFCOMM service query failed: {result.Error}");
            }

            if (result.Services.Count == 0)
            {
                throw new InvalidOperationException($"No RFCOMM service found for '{deviceId}'.");
            }

            var rfcommService = result.Services[0];
            StreamSocket? socket = null;

            try
            {
                socket = new StreamSocket();

                try
                {
                    await socket.ConnectAsync(
                        rfcommService.ConnectionHostName,
                        rfcommService.ConnectionServiceName,
                        SocketProtectionLevel.BluetoothEncryptionAllowNullAuthentication)
                        .AsTask()
                        .ConfigureAwait(false);

                    // Transfer ownership of the socket to WindowsBluetoothConnection
                    var connection = new WindowsBluetoothConnection(socket, deviceId);
                    socket = null; // prevent double-dispose in outer finally
                    return connection;
                }
                finally
                {
                    rfcommService.Dispose();
                }
            }
            finally
            {
                // Dispose socket if ownership was not transferred
                socket?.Dispose();
            }
        }
        finally
        {
            bluetoothDevice.Dispose();
        }
    }
}