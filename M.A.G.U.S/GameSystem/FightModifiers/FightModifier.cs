namespace M.A.G.U.S.GameSystem.FightModifiers;

public sealed class FightModifier : IFightModifier
{
    public int InitiatingValue { get; set; }

    public int AttackingValue { get; set; }

    public int DefendingValue { get; set; }

    public int AimingValue { get; set; }

    public int CombatModifier { get; set; }
}
