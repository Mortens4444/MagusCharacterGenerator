namespace M.A.G.U.S.GameSystem.FightModifiers;

public class FightWithHate : ICombatModifier
{
    public int InitiateValue => 3;

    public int AttackValue => 10;

    public int DefenseValue => -20;

    public int AimValue => -20;
}
