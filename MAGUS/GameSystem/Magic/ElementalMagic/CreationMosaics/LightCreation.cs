namespace MAGUS.GameSystem.Magic.ElementalMagic.CreationMosaics;

/// <summary>
/// Fény Teremtése (p. 294). Creates Elemi Fény at 2 Mp per E, no direct damage. The book maps
/// E to a real-world light-source-equivalent description; the source table's rows for E 9-10
/// were lost to a PDF extraction gap between "campfire light" (E8) and "daylight under an
/// overcast sky" (E11 onward per the book), so this fills that gap with the two remaining
/// described sources ("bonfire light", "dusk light") rather than leaving a hole - worth a
/// spot-check against the physical book.
/// </summary>
public sealed class LightCreation : IElementCreationMosaic
{
    private static readonly (int MinStrength, string Description)[] Table =
    [
        (1, "matchstick flame"),
        (2, "small candle flame"),
        (3, "reading candle flame"),
        (4, "church candle flame"),
        (5, "oil lamp flame"),
        (6, "torch flame"),
        (7, "large torch flame"),
        (8, "campfire light"),
        (9, "bonfire light"),
        (10, "dusk light"),
        (11, "daylight under an overcast sky"),
        (12, "hazy daylight"),
        (13, "full sunlight"),
        (14, "noon glare"),
        (15, "blinding light"),
        (20, "permanent blindness if the eyes are open"),
    ];

    public string Name => "Light Creation";

    public int CastingTimeInSegments => 2;

    public int GetManaCost(int strength) => Validate(strength) * 2;

    public CreatedElement Create(int strength)
    {
        Validate(strength);
        return new CreatedElement { ParaElement = ParaElementType.Light, Strength = strength };
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
