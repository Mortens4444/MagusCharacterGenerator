namespace M.A.G.U.S.GameSystem.FightModifiers;

public class Charge : ICombatModifier
{
    public int InitiateValue => 0;

    public int AttackValue => 20;

    public int DefenseValue => -25;

    public int AimValue => -30;
}
