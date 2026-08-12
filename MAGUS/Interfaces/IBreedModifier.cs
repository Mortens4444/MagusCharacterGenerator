namespace MAGUS.Interfaces;

public interface IBreedModifier
{
    int InitiateValue { get; }

    int AttackValue { get; }

    int DefenseValue { get; }

    int AimValue { get; }

    int ExtraDamage { get; }

    int ExtraHealtPoints { get; }

    int ExtraPainTolerancePoints { get; }

    int ExtraExperiancePoints { get; }
}
