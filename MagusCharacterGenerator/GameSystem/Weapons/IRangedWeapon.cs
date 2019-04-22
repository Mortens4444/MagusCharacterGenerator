namespace MagusCharacterGenerator.GameSystem.Weapons
{
    interface IRangedWeapon : IWeapon
    {
        byte AimingValue { get; }

        ushort Distance { get; }
    }
}