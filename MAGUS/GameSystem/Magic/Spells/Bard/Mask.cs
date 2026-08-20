using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Maszk (Bárd — Fénymágia, Első Törvénykönyv p.146). Two use modes in the book: disguises the
/// bard's own face as a generic humanoid face, or hides the bard's true facial expressions
/// (masking emotions/tells). Different durations (2 kör/szint vs 5 perc/szint); 20 rounds shown as
/// a representative level-1 baseline, not level-scaled.
/// </summary>
public sealed class Mask : ISpell
{
    public string Name => "Mask";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 2;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 3;

    public int DurationInRounds => 20;

    public int GetDamage() => 0;
}
