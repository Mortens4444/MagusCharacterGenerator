namespace MAGUS.Interfaces;

public interface IMeleeWeapon : IWeapon
{
    int AttackValue { get; }

    int DefenseValue { get; }
}