namespace M.A.G.U.S.GameSystem.FightModifiers;

public class AttackFromBehind : IFightModifier
{
    public int InitiatingValue => 5;

    public int AttackValue => 10;

    public int DefenseValue => 0;

    public int? AimingValue => 0;
}
