namespace MAGUS.GameSystem.Magic.ElementalMagic.Forms;

/// <summary>
/// Nyíl (p. 295). Single-target attack: a bolt of the created element, fixed accuracy 30,
/// unparryable but reduced by the target's armor SFÉ. Instantaneous.
/// </summary>
public sealed class Arrow : IMosaicForm
{
    public const int Accuracy = 30;

    public string Name => "Arrow";

    public int DurationInRounds => 0;

    public int GetDamage(CreatedElement element) => element.Damage;
}
