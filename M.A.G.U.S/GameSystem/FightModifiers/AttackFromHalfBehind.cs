namespace M.A.G.U.S.GameSystem.FightModifiers;

public class AttackFromHalfBehind : IFightModifier
{
    public int InitiatingValue => 2;

    public int AttackValue => 5;

    public int DefenseValue => 0;

    public int? AimingValue => 0;
}
