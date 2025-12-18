namespace M.A.G.U.S.GameSystem.FightModifiers;

public class FightUnderFear : IFightModifier
{
    public int InitiatingValue => -10;

    public int AttackValue => -15;

    public int DefenseValue => +5;

    public int? AimingValue => -20;
}
