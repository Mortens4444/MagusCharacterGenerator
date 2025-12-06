namespace M.A.G.U.S.GameSystem.FightModifiers;

public class FightWithHate : IFightModifier
{
    public int InitiatingValue => 3;

    public int AttackingValue => 10;

    public int DefendingValue => -20;

    public int AimingValue => -20;
}
