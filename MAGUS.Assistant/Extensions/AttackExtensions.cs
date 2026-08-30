using MAGUS.GameSystem;
using Mtf.LanguageService;

namespace MAGUS.Assistant.Extensions;

internal static class AttackExtensions
{
    /// <summary>
    /// Translated display label for an attack mode, tagged with which weapon slot it came from when
    /// that's ambiguous otherwise - dual-wielding two of the same weapon (a common two-handed-fighting
    /// setup) gives the primary and secondary MeleeAttack/RangedAttack the same Attack.Name, so without
    /// this tag the attack-mode picker and the "Attack mode: ..." button would show two identical
    /// entries with no way to tell which is which.
    /// </summary>
    public static string GetDisplayLabel(this Attack attack, Character character)
    {
        var name = Lng.Elem(attack.Name);
        object? weapon = attack switch
        {
            MeleeAttack melee => melee.Weapon,
            RangedAttack ranged => ranged.Weapon,
            _ => null
        };

        if (weapon != null && ReferenceEquals(weapon, character.PrimaryWeapon))
        {
            return $"{name} ({Lng.Elem("Primary weapon")})";
        }

        if (weapon != null && ReferenceEquals(weapon, character.SecondaryWeapon))
        {
            return $"{name} ({Lng.Elem("Secondary weapon")})";
        }

        return name;
    }
}
