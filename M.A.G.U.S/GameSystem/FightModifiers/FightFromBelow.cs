namespace M.A.G.U.S.GameSystem.FightModifiers;

public class FightFromBelow : IFightModifier
{
    public int InitiatingValue => -2;

    public int AttackValue => -10;

    public int DefenseValue => 0;

    public int? AimingValue => -5;
}
