namespace M.A.G.U.S.GameSystem.FightModifiers;

public class FightUnderFear : IFightModifier
{
    public short InitiatingValue => -10;

    public short AttackingValue => -15;

    public short DefendingValue => +5;

    public short AimingValue => -20;
}
