namespace MAGUS.GameSystem.Magic.ElementalMagic.Forms;

/// <summary>
/// Szőnyeg (p. 295-296). Ground-level area effect, 3 rounds: the caster picks a radius (feet)
/// between 1 and the element's Strength (E); the effective Strength - and per-round damage -
/// is E divided by that radius, rounded down.
/// </summary>
public sealed class Carpet : IMosaicForm
{
    public string Name => "Carpet";

    public int DurationInRounds => 3;

    public int GetEffectiveStrength(CreatedElement element, int radiusFeet) => AreaFormMath.GetEffectiveStrength(element, radiusFeet);

    public int GetDamagePerRound(CreatedElement element, int radiusFeet) => GetEffectiveStrength(element, radiusFeet);
}
