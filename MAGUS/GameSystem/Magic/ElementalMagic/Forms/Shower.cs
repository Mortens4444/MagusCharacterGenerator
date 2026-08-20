namespace MAGUS.GameSystem.Magic.ElementalMagic.Forms;

/// <summary>
/// Zápor (p. 296), an Irregular Elemental Form: an overhead variant of Carpet that rains down
/// for 3 rounds, using the same radius/effective-Strength rule.
/// </summary>
public sealed class Shower : IMosaicForm
{
    public string Name => "Shower";

    public int DurationInRounds => 3;

    public int GetEffectiveStrength(CreatedElement element, int radiusFeet) => AreaFormMath.GetEffectiveStrength(element, radiusFeet);

    public int GetDamagePerRound(CreatedElement element, int radiusFeet) => GetEffectiveStrength(element, radiusFeet);
}
