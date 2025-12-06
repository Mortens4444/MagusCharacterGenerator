namespace M.A.G.U.S.GameSystem.FightModifiers;

public class DefendingFight : IFightModifier
{
    public int InitiatingValue => int.MinValue;

    public int AttackingValue => 0;

    public int DefendingValue => 40;

    public int AimingValue => 0;
}
