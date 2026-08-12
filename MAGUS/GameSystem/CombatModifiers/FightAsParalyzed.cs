using MAGUS.Interfaces;

namespace MAGUS.GameSystem.CombatModifiers;

public class FightAsParalyzed : ICombatModifier
{
    public int InitiateValue => -30;

    public int AttackValue => -40;

    public int DefenseValue => -35;

    public int AimValue => -15;
}
