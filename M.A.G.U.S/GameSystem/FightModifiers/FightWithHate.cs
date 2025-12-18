namespace M.A.G.U.S.GameSystem.FightModifiers;

public class FightWithHate : IFightModifier
{
    public int InitiatingValue => 3;

    public int AttackValue => 10;

    public int DefenseValue => -20;

    public int? AimingValue => -20;
}
