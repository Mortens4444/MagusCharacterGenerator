using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Mágia megjelenítés (Bárd — Fénymágia, Első Törvénykönyv p.145). Conjures the pure visual
/// appearance of any spell effect (a summoning, an elemental blast, etc.) with no real effect —
/// no damage, no sound. Duration is 1 perc/szint in the book; level-1 baseline shown, not
/// level-scaled.
/// </summary>
public sealed class MagicDisplay : ISpell
{
    public string Name => "Magic display";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 6;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 60;

    public int GetDamage() => 0;
}
