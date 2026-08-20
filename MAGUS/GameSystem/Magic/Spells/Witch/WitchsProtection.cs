using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Védelem (Boszorkány — Bájolás, Első Törvénykönyv p.221). A delayed-trigger ward that only
/// activates when a previously-touched man is about to turn violent against the witch
/// specifically; the trigger condition isn't modeled, this represents only the base spell's
/// cost/duration. Duration is 5 perc/szint in the book; level-1 baseline shown, not level-scaled.
/// </summary>
public sealed class WitchsProtection : ISpell
{
    public string Name => "Witch's protection";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 9;

    public int ManaCost => 15;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Mental;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 30;

    public int GetDamage() => 0;
}
