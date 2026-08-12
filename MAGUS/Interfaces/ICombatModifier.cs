namespace MAGUS.Interfaces;

public interface ICombatModifier
{
    int InitiateValue { get; }

    int AttackValue { get; }

    int DefenseValue { get; }

    int AimValue { get; }
}
