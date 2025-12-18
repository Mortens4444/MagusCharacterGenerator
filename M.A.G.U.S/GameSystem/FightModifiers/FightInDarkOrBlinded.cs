namespace M.A.G.U.S.GameSystem.FightModifiers;

public class FightInDarkOrBlinded : IFightModifier
{
    public int InitiatingValue => -20;

    public int AttackValue => -60;

    public int DefenseValue => -70;

    public int? AimingValue => -150;
}
