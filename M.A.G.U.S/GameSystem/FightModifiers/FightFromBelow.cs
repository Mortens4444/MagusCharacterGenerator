namespace M.A.G.U.S.GameSystem.FightModifiers;

public class FightFromBelow : IFightModifier
{
    public short InitiatingValue => -2;

    public short AttackingValue => -10;

    public short DefendingValue => 0;

    public short AimingValue => -5;
}
