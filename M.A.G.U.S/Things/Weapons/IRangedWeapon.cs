using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.Things.Weapons;

public interface IRangedWeapon : IWeapon
{
    int AimValue { get; }

    int Distance { get; }
}