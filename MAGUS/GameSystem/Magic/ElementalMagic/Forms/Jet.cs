namespace MAGUS.GameSystem.Magic.ElementalMagic.Forms;

/// <summary>
/// Csóva (p. 297), an Irregular Elemental Form: a directed, continuous variant of Burst -
/// length in feet equals the element's Strength (E), damage falls off by 1 per foot from the
/// origin, and unlike Burst it flows for a full round rather than resolving instantly.
/// </summary>
public sealed class Jet : IMosaicForm
{
    public string Name => "Jet";

    public int DurationInRounds => 1;

    public int GetLengthFeet(CreatedElement element) => element.Strength;

    public int GetDamageAtDistance(CreatedElement element, int feetFromOrigin)
    {
        if (feetFromOrigin < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(feetFromOrigin));
        }

        return Math.Max(0, element.Damage - feetFromOrigin);
    }
}
