namespace MAGUS.Assistant.Interfaces.Bluetooth;

internal interface IBluetoothConnector
{
    /// <summary>Connect to a device by id/address and return the connection.</summary>
    Task<IBluetoothConnection> ConnectToAsync(string deviceId);
}
