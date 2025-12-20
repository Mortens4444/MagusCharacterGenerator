namespace M.A.G.U.S.GameSystem.CombatModifiers;

public class FightInDarkOrBlinded : ICombatModifier
{
    public int InitiateValue => -20;

    public int AttackValue => -60;

    public int DefenseValue => -70;

    public int AimValue => -150;
}
