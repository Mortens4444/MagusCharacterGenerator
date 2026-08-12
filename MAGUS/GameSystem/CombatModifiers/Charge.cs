using MAGUS.Interfaces;

namespace MAGUS.GameSystem.CombatModifiers;

public class Charge : ICombatModifier
{
    public int InitiateValue => 0;

    public int AttackValue => 20;

    public int DefenseValue => -25;

    public int AimValue => -30;
}
