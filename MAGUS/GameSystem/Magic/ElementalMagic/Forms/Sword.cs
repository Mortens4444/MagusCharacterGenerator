using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.ElementalMagic.Forms;

/// <summary>
/// Kard (p. 295). Wraps the created element around a one-handed melee weapon's blade: normal
/// weapon damage plus the element's damage, using the weapon's usual attack/defense values.
/// Lasts 5 rounds.
/// </summary>
public sealed class Sword : IMosaicForm
{
    public string Name => "Sword";

    public int DurationInRounds => 5;

    public int GetDamage(CreatedElement element, IWeapon weapon) => weapon.GetDamage() + element.Damage;
}
