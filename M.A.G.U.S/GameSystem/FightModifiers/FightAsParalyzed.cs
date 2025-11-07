namespace M.A.G.U.S.GameSystem.FightModifiers;

public class FightAsParalyzed : IFightModifier
{
    public short InitiatingValue => -30;

    public short AttackingValue => -40;

    public short DefendingValue => -35;

    public short AimingValue => -15;
}
