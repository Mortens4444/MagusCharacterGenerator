namespace M.A.G.U.S.GameSystem.CombatModifiers;

public class FightUnderFear : ICombatModifier
{
    public int InitiateValue => -10;

    public int AttackValue => -15;

    public int DefenseValue => +5;

    public int AimValue => -20;
}
