namespace MAGUS.GameSystem.Magic.ElementalMagic;

/// <summary>
/// One of the six mosaics (varázslat-mozaikok) that create a quantity of element at a
/// caster-chosen Strength (E). Source: p. 292-297.
/// </summary>
public interface IElementCreationMosaic
{
    string Name { get; }

    int CastingTimeInSegments { get; }

    /// <summary>Mana-point cost of creating the element at the given Strength (E).</summary>
    int GetManaCost(int strength);
}
