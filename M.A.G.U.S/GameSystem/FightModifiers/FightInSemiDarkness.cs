namespace M.A.G.U.S.GameSystem.FightModifiers;

public class FightInSemiDarkness : IFightModifier
{
    public int InitiatingValue => -15;

    public int AttackValue => -30;

    public int DefenseValue => -35;

    public int? AimingValue => -70;
}
