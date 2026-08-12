using MAGUS.Interfaces;

namespace MAGUS.GameSystem.CombatModifiers;

public class AttackFromBehind : ICombatModifier
{
    public int InitiateValue => 5;

    public int AttackValue => 10;

    public int DefenseValue => 0;

    public int AimValue => 0;
}
