using MAGUS.Interfaces;

namespace MAGUS.GameSystem.CombatModifiers;

public class FightAsDizzily : ICombatModifier
{
    public int InitiateValue => -15;

    public int AttackValue => -20;

    public int DefenseValue => -25;

    public int AimValue => -30;
}
