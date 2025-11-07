namespace M.A.G.U.S.GameSystem.FightModifiers;

public class FightFromAbove : IFightModifier
{
    public short InitiatingValue => 2;

    public short AttackingValue => 5;

    public short DefendingValue => 0;

    public short AimingValue => 5;
}
