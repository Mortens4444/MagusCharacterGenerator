using M.A.G.U.S.Enums;

namespace M.A.G.U.S.GameSystem.Turn;

public sealed class InitiativeEntry
{
    public required CombatantRef Attacker { get; init; }

    public required CombatantRef Target { get; init; }

    public required Attack? SelectedAttack { get; init; }

    public ResolutionBase? AttackOrAimResolution { get; set; }

    public InitiativeEntryKind Kind { get; set; } = InitiativeEntryKind.Attack;

    public int BaseInitiative { get; init; }

    public int RolledValue { get; init; }

    public int FinalInitiative => BaseInitiative + RolledValue;
}
