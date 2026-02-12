using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.GameSystem.Turn;

public sealed class CombatantRef(Attacker source, string? name = null)
{
    public Guid Id { get; init; } = Guid.NewGuid();

    public string Name { get; private set; } = name ?? source.Name;

    public Attacker Source { get; private set; } = source;

    public void AddTemporaryModifier(ICombatModifier combatModifier)
    {
        Source.AddTemporaryModifier(combatModifier);
    }

    public void RemoveTemporaryModifiers()
    {
        Source.RemoveTemporaryModifiers();
    }
}
