namespace M.A.G.U.S.GameSystem.FightModifiers;

public class FightAsParalyzed : IFightModifier
{
    public int InitiatingValue => -30;

    public int AttackValue => -40;

    public int DefenseValue => -35;

    public int? AimingValue => -15;
}
