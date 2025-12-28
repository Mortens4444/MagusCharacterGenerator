using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.GameSystem.CombatModifiers;

public class FightFromMovingHorse : ICombatModifier
{
    public int InitiateValue => 5;

    public int AttackValue => 10;

    public int DefenseValue => 20;

    public int AimValue => -20;
}
