using MAGUS.Interfaces;

namespace MAGUS.GameSystem.CombatModifiers;

public class WeaponCombatModifier : ICombatModifier
{
    public int InitiateValue { get; set; }

    public int AttackValue { get; set; }

    public int DefenseValue { get; set; }

    public int AimValue { get; set; }
}
