namespace M.A.G.U.S.Assistant.Messages;

public sealed class BluetoothMessage
{
    public string CommandType { get; init; } = String.Empty;

    public string SenderId { get; init; } = String.Empty;

    public IReadOnlyCollection<string> TargetIds { get; init; } = [];

    public string Payload { get; init; } = String.Empty;
}
