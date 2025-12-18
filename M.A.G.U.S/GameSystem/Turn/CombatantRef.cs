namespace M.A.G.U.S.GameSystem.Turn;

public sealed class CombatantRef
{
    public Guid Id { get; init; } = Guid.NewGuid();

    public required string Name { get; init; }

    public required Attacker Source { get; init; }
}
