namespace MAGUS.GameSystem.Magic.ElementalMagic.Forms;

/// <summary>
/// Sátor (p. 297), an Irregular Elemental Form: a hemisphere shell (Wall's formula, not
/// Carpet's - it's a Szőnyeg+Fal hybrid per the book), 3 rounds.
/// </summary>
public sealed class Tent : IMosaicForm
{
    public string Name => "Tent";

    public int DurationInRounds => 3;

    public int GetEffectiveStrength(CreatedElement element, int radiusFeet) => AreaFormMath.GetEffectiveStrength(element, radiusFeet);

    public int GetDamagePerRound(CreatedElement element, int radiusFeet) => GetEffectiveStrength(element, radiusFeet);
}
