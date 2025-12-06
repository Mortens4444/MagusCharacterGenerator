namespace M.A.G.U.S.GameSystem.FightModifiers;

public class FightUnderFear : IFightModifier
{
    public int InitiatingValue => -10;

    public int AttackingValue => -15;

    public int DefendingValue => +5;

    public int AimingValue => -20;
}
