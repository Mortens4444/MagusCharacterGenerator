using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Szín varázs (Bárd — Fénymágia, Első Törvénykönyv p.147-148). Recolors a small area (not living
/// tissue) in any color. Duration is 1 nap/szint in the book; level-1 baseline (24 hours = 8640
/// rounds) shown, not level-scaled. Purely cosmetic.
/// </summary>
public sealed class ColorSpell : ISpell
{
    public string Name => "Color spell";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 1;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 8640;

    public int GetDamage() => 0;
}
