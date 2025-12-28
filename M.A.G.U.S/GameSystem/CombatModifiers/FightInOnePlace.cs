using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.GameSystem.CombatModifiers;

public class FightInOnePlace : ICombatModifier
{
    public int InitiateValue => -20;

    public int AttackValue => -15;

    public int DefenseValue => -5;

    public int AimValue => 0;
}
