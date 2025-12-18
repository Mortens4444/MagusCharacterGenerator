namespace M.A.G.U.S.GameSystem.FightModifiers;

public class Charge : IFightModifier
{
    public int InitiatingValue => 0;

    public int AttackValue => 20;

    public int DefenseValue => -25;

    public int? AimingValue => -30;
}
