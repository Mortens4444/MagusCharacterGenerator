namespace MAGUS.GameSystem.Magic.ElementalMagic;

/// <summary>
/// Opposite elements weaken - or fully cancel - each other: the weaker one stops existing,
/// the stronger one loses the weaker one's Strength (E); equal Strengths annihilate both.
/// Source: p. 292-293. Pairs: Fire↔Water, Earth↔Air, Heat↔Frost, Light↔Darkness.
/// </summary>
public static class ElementOpposition
{
    public static bool AreOpposite(CreatedElement a, CreatedElement b)
    {
        if (a.OsElement.HasValue && b.OsElement.HasValue)
        {
            return (a.OsElement, b.OsElement) is (OsElementType.Fire, OsElementType.Water)
                or (OsElementType.Water, OsElementType.Fire)
                or (OsElementType.Earth, OsElementType.Air)
                or (OsElementType.Air, OsElementType.Earth);
        }

        if (a.ParaElement.HasValue && b.ParaElement.HasValue)
        {
            return (a.ParaElement, b.ParaElement) is (ParaElementType.Heat, ParaElementType.Frost)
                or (ParaElementType.Frost, ParaElementType.Heat)
                or (ParaElementType.Light, ParaElementType.Darkness)
                or (ParaElementType.Darkness, ParaElementType.Light);
        }

        return false;
    }

    /// <summary>
    /// Resolves a clash between two opposite elements. Returns null when they fully cancel
    /// (equal Strength); otherwise returns the survivor with its Strength (and, for primal
    /// elements, its damage - proportionally reduced, since the book doesn't reroll dice for
    /// a partial cancellation) reduced by the weaker element's Strength.
    /// </summary>
    public static CreatedElement? Cancel(CreatedElement a, CreatedElement b)
    {
        if (!AreOpposite(a, b))
        {
            throw new ArgumentException("The two elements are not an opposite pair.");
        }

        if (a.Strength == b.Strength)
        {
            return null;
        }

        var (stronger, weaker) = a.Strength > b.Strength ? (a, b) : (b, a);
        var remainingStrength = stronger.Strength - weaker.Strength;
        var remainingDamage = stronger.Damage * remainingStrength / stronger.Strength;

        return stronger with { Strength = remainingStrength, Damage = remainingDamage };
    }
}
