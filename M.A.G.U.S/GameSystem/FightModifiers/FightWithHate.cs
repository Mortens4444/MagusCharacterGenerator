namespace M.A.G.U.S.GameSystem.FightModifiers;

public class FightWithHate : IFightModifier
{
    public short InitiatingValue => 3;

    public short AttackingValue => 10;

    public short DefendingValue => -20;

    public short AimingValue => -20;
}
