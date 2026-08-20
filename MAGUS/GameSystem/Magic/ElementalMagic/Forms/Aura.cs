namespace MAGUS.GameSystem.Magic.ElementalMagic.Forms;

/// <summary>
/// Aura (p. 296). Personal shield, 2 rounds: blocks opposite-element Arrow/Sword/Burst
/// attacks like a Wall would. When shaped from Elemental Force, its Strength (E) doubles as
/// an SFÉ (armor value) against physical damage.
/// </summary>
public sealed class Aura : IMosaicForm
{
    public string Name => "Aura";

    public int DurationInRounds => 2;

    public int GetArmorValue(CreatedElement element)
    {
        if (!element.IsElementalForce)
        {
            throw new InvalidOperationException("Only an Elemental Force Aura grants an armor value.");
        }

        return element.Strength;
    }
}
