namespace M.A.G.U.S.GameSystem.FightModifiers;

public sealed class FightModifier : IFightModifier
{
    public short InitiatingValue { get; set; }

    public short AttackingValue { get; set; }

    public short DefendingValue { get; set; }

    public short AimingValue { get; set; }

    public short CombatModifier { get; set; }
}
