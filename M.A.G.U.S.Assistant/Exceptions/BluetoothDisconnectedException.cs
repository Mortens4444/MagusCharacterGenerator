namespace M.A.G.U.S.Assistant.Exceptions;

internal sealed class BluetoothDisconnectedException(string message)
    : IOException(message)
{ }