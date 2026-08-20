using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Tárgyalkotás (Bárd — Fénymágia, Első Törvénykönyv p.142). Conjures the illusory image of any
/// object (up to 1/2 köbláb per level); it can look like a weapon but deals no damage, since it's
/// intangible. Duration is 3 perc/szint in the book; level-1 baseline shown, not level-scaled.
/// </summary>
public sealed class ObjectCreation : ISpell
{
    public string Name => "Object creation";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 5;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 18;

    public int GetDamage() => 0;
}
