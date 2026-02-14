namespace M.A.G.U.S.Assistant.Models;

internal sealed class ExperienceLevelDisplay
{
    public int Level { get; init; }
    public ulong Min { get; init; }
    public ulong Max { get; init; }

    public string Range => $"{Min:N0} – {Max:N0}";
}
