namespace MAGUS.GameSystem.Magic.ElementalMagic.Forms;

/// <summary>
/// Fal (p. 296). Defensive half-circle wall, 6 rounds: same radius/effective-Strength rule as
/// Carpet. Blocks or weakens opposing elemental attacks per the elemental cancellation rule
/// (<see cref="ElementOpposition"/>), and deals its effective Strength as damage per round to
/// anything passing through it.
/// </summary>
public sealed class Wall : IMosaicForm
{
    public string Name => "Wall";

    public int DurationInRounds => 6;

    public int GetEffectiveStrength(CreatedElement element, int radiusFeet) => AreaFormMath.GetEffectiveStrength(element, radiusFeet);

    public int GetDamagePerRound(CreatedElement element, int radiusFeet) => GetEffectiveStrength(element, radiusFeet);
}
