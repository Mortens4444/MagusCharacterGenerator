using MAGUS.Extensions;
using MAGUS.GameSystem;
using MAGUS.Interfaces;
using MAGUS.Models;

namespace MAGUS.Things.Weapons;

public abstract class Weapon : Thing, IWeapon
{
    protected readonly DiceThrow DiceThrow = new();

    public abstract double AttacksPerRound { get; }

    public abstract int InitiateValue { get; }

    /// <summary>
    /// Whether wielding this weapon takes both hands at once (Első Törvénykönyv, "Kétkezes
    /// fegyverek") - a weapon this slow or this heavy relative to its peers takes both hands to
    /// swing, so it occupies PrimaryWeapon and SecondaryWeapon simultaneously (see
    /// Character.PrimaryWeapon/SecondaryWeapon setters) instead of leaving the off hand free. A
    /// sub-1-attack-per-round weapon is the proxy for both "slow" and "unusually heavy" - a weapon
    /// heavy enough to need both hands already gets that reflected as a below-1 AttacksPerRound in
    /// this catalog, so there's no separate weight threshold to maintain. Shield overrides this back
    /// to false - a shield occupies one hand/arm by design, it doesn't need the other hand free the
    /// way a two-handed weapon's off hand does.
    /// </summary>
    public virtual bool IsTwoHanded => AttacksPerRound < 1;

    public abstract int GetDamage();

    public DiceThrowFormula? DamageFormula
    {
        get
        {
            var customAttributes = GetType().GetMethod(nameof(GetDamage))?.GetCustomAttributes(false);
            return customAttributes.GetDiceThrowFormula();
        }
    }
}