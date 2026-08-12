namespace MAGUS.Interfaces;

public interface IRangedWeapon : IWeapon
{
    int AimValue { get; }

    /// <summary>
    /// Distance in meters
    /// </summary>
    int Distance { get; }
}