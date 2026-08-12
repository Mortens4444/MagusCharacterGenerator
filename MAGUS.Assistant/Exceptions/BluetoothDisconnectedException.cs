namespace MAGUS.Assistant.Exceptions;

internal sealed class BluetoothDisconnectedException(string message)
    : IOException(message)
{ }