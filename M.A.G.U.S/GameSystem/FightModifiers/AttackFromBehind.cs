namespace M.A.G.U.S.GameSystem.FightModifiers;

public class AttackFromBehind : IFightModifier
{
    public int InitiatingValue => 5;

    public int AttackingValue => 10;

    public int DefendingValue => 0;

    public int AimingValue => 0;
}
