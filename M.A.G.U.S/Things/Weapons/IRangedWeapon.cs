namespace M.A.G.U.S.Things.Weapons;

public interface IRangedWeapon : IWeapon
{
    byte AimingValue { get; }

    ushort Distance { get; }
}