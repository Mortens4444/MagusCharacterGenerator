namespace M.A.G.U.S.GameSystem.FightModifiers;

public class DefendingFight : IFightModifier
{
    public int InitiatingValue => int.MinValue;

    public int AttackValue => 0;

    public int DefenseValue => 40;

    public int? AimingValue => 0;
}
