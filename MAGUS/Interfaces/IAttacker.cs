namespace MAGUS.Interfaces;

public interface IAttacker
{
    int InitiateBaseValue { get; }

    int AttackBaseValue { get; }

    int DefenseBaseValue { get; }

    int AimBaseValue { get; }
}
