namespace M.A.G.U.S.Interfaces;

public interface IRangedWeapon : IWeapon
{
    int AimValue { get; }

    int Distance { get; }
}