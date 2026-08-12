using MAGUS.Assistant.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MAGUS.Assistant.Messages;

internal sealed class BluetoothMessage
{
    //[JsonConverter(typeof(StringEnumConverter))]
    public BluetoothCommandType CommandType { get; init; }

    public string SenderId { get; init; } = String.Empty;

    public IReadOnlyCollection<string> TargetIds { get; init; } = [];

    public string Payload { get; init; } = String.Empty;
}
