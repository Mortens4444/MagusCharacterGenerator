namespace MAGUS.GameSystem.Magic.ElementalMagic.Forms;

/// <summary>
/// Shared math for the radius-chosen area forms (Carpet/Wall/Shower/Dome/Tent): the caster
/// picks a radius between 1 foot and the element's Strength (E); the form's own effective
/// Strength - and so its per-round damage - is the element's E divided by that radius,
/// rounded down. Source: p. 295-296 (Szőnyeg).
/// </summary>
internal static class AreaFormMath
{
    public static int GetEffectiveStrength(CreatedElement element, int radiusFeet)
    {
        if (radiusFeet < 1 || radiusFeet > element.Strength)
        {
            throw new ArgumentOutOfRangeException(nameof(radiusFeet), "Radius must be between 1 and the element's Strength (E).");
        }

        return element.Strength / radiusFeet;
    }
}
