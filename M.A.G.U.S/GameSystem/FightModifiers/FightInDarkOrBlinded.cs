namespace M.A.G.U.S.GameSystem.FightModifiers;

public class FightInDarkOrBlinded : IFightModifier
{
    public int InitiatingValue => -20;

    public int AttackingValue => -60;

    public int DefendingValue => -70;

    public int AimingValue => -150;
}
