using MAGUS.Interfaces;

namespace MAGUS.GameSystem.CombatModifiers;

public class FightToGetHostage : ICombatModifier
{
    public int InitiateValue => -5;

    public int AttackValue => -5;

    public int DefenseValue => -15;

    public int AimValue => 0;
}
