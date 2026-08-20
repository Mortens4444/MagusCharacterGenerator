namespace MAGUS.GameSystem.Magic.ElementalMagic.Forms;

/// <summary>
/// Kupola (p. 297), an Irregular Elemental Form: a hemisphere variant of Carpet, 2 rounds,
/// same radius/effective-Strength rule - but works only with para-elements, not primal
/// elements or Elemental Force.
/// </summary>
public sealed class Dome : IMosaicForm
{
    public string Name => "Dome";

    public int DurationInRounds => 2;

    public int GetEffectiveStrength(CreatedElement element, int radiusFeet)
    {
        RequireParaElement(element);
        return AreaFormMath.GetEffectiveStrength(element, radiusFeet);
    }

    public int GetDamagePerRound(CreatedElement element, int radiusFeet) => GetEffectiveStrength(element, radiusFeet);

    private static void RequireParaElement(CreatedElement element)
    {
        if (element.ParaElement is null)
        {
            throw new InvalidOperationException("Dome can only be shaped from a para-element (Heat, Frost, Light, or Darkness).");
        }
    }
}
