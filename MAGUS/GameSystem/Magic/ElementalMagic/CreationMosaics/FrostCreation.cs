namespace MAGUS.GameSystem.Magic.ElementalMagic.CreationMosaics;

/// <summary>
/// Fagy Teremtése (p. 294). Lowers temperature by 10°C per E, costing 2 Mp per E. Damage
/// depends on the resulting absolute temperature, which needs an ambient baseline the book
/// leaves to the GM rather than a fixed number, so the caller supplies it.
/// </summary>
public sealed class FrostCreation : IElementCreationMosaic
{
    private const int DamageThresholdCelsius = -40;

    public string Name => "Frost Creation";

    public int CastingTimeInSegments => 2;

    public int GetManaCost(int strength) => Validate(strength) * 2;

    public int GetTemperatureDecrease(int strength) => Validate(strength) * 10;

    public CreatedElement Create(int strength)
    {
        Validate(strength);
        return new CreatedElement { ParaElement = ParaElementType.Frost, Strength = strength };
    }

    /// <summary>2 Sp once the resulting temperature reaches -40°C, +2 Sp per further 10°C below that.</summary>
    public int GetDamage(int resultingTemperatureCelsius) =>
        resultingTemperatureCelsius <= DamageThresholdCelsius
            ? 2 + (DamageThresholdCelsius - resultingTemperatureCelsius) / 10 * 2
            : 0;

    private static int Validate(int strength) =>
        strength > 0 ? strength : throw new ArgumentOutOfRangeException(nameof(strength), "Strength (E) must be at least 1.");
}
