namespace M.A.G.U.S.GameSystem.Turn;

public sealed class TurnData
{
    public int Round { get; init; }

    public List<InitiativeEntry> Initiatives { get; } = [];

    public DateTime StartedAt { get; init; } = DateTime.UtcNow;
}
