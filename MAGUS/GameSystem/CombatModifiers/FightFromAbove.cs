using MAGUS.Interfaces;

namespace MAGUS.GameSystem.CombatModifiers;

public class FightFromAbove : ICombatModifier
{
    public int InitiateValue => 2;

    public int AttackValue => 5;

    public int DefenseValue => 0;

    public int AimValue => 5;
}
