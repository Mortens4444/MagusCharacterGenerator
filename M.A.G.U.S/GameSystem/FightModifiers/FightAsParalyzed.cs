namespace M.A.G.U.S.GameSystem.FightModifiers;

public class FightAsParalyzed : ICombatModifier
{
    public int InitiateValue => -30;

    public int AttackValue => -40;

    public int DefenseValue => -35;

    public int AimValue => -15;
}
