namespace MAGUS.GameSystem.Magic.ElementalMagic.CreationMosaics;

/// <summary>
/// Sötét Teremtése (p. 294). Creates Elemi Sötét at 2 Mp per E (same cost as Light Creation,
/// per the book's "Hasonló a Fény Teremtése varázslathoz"), no direct damage. E maps to a
/// darkness-level description.
/// </summary>
public sealed class DarknessCreation : IElementCreationMosaic
{
    private static readonly (int MinStrength, string Description)[] Table =
    [
        (1, "dusk"),
        (2, "full moon"),
        (3, "waning moon"),
        (4, "new moon"),
        (5, "starlit night"),
        (6, "overcast night"),
        (7, "night in an unlit room"),
        (8, "in a cave"),
        (9, "pitch dark"),
        (10, "Kráni darkness"),
        (11, "even ultravision and infravision fail"),
    ];

    public string Name => "Darkness Creation";

    public int CastingTimeInSegments => 2;

    public int GetManaCost(int strength) => Validate(strength) * 2;

    public CreatedElement Create(int strength)
    {
        Validate(strength);
        return new CreatedElement { ParaElement = ParaElementType.Darkness, Strength = strength };
    }

    public string GetDescription(int strength)
    {
        Validate(strength);
        var match = Table.LastOrDefault(row => row.MinStrength <= strength);
        return match.Description ?? Table[0].Description;
    }

    private static int Validate(int strength) =>
        strength > 0 ? strength : throw new ArgumentOutOfRangeException(nameof(strength), "Strength (E) must be at least 1.");
}
