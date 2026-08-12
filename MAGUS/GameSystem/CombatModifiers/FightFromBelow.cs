using MAGUS.Interfaces;

namespace MAGUS.GameSystem.CombatModifiers;

public class FightFromBelow : ICombatModifier
{
    public int InitiateValue => -2;

    public int AttackValue => -10;

    public int DefenseValue => 0;

    public int AimValue => -5;
}
