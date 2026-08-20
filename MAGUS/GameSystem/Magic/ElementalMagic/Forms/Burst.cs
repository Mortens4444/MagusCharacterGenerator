namespace MAGUS.GameSystem.Magic.ElementalMagic.Forms;

/// <summary>
/// Kitörés (p. 296). Instantaneous area explosion: radius in feet equals the element's
/// Strength (E); damage falls off by 1 per foot from the epicenter.
/// </summary>
public sealed class Burst : IMosaicForm
{
    public string Name => "Burst";

    public int DurationInRounds => 0;

    public int GetRadiusFeet(CreatedElement element) => element.Strength;

    public int GetDamageAtDistance(CreatedElement element, int feetFromEpicenter)
    {
        if (feetFromEpicenter < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(feetFromEpicenter));
        }

        return Math.Max(0, element.Damage - feetFromEpicenter);
    }
}
