namespace M.A.G.U.S.Interfaces;

public interface IMeleeWeapon : IWeapon
{
    int AttackValue { get; }

    int DefenseValue { get; }
}