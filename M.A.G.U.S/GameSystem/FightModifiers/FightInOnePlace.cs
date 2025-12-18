namespace M.A.G.U.S.GameSystem.FightModifiers;

public class FightInOnePlace : ICombatModifier
{
    public int InitiateValue => -20;

    public int AttackValue => -15;

    public int DefenseValue => -5;

    public int AimValue => 0;
}
