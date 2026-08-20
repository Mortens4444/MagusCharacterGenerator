using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Képidézés (Bárd — Fénymágia, Első Törvénykönyv p.143). Recalls a past event the bard actually
/// witnessed as a visual illusion, from memory — the light-based counterpart to Hangidézés. Duration
/// is perc/szint in the book; level-1 baseline shown, not level-scaled.
/// </summary>
public sealed class ImageRecall : ISpell
{
    public string Name => "Image recall";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 9;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 50;

    public int DurationInRounds => 6;

    public int GetDamage() => 0;
}
