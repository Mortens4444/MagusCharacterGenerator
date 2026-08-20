using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Alakváltás (Bárd — Fénymágia, Első Törvénykönyv p.142). Changes the bard's apparent form —
/// gender, height, weight can all shift freely, and a specific person's likeness can be taken on
/// (30 Mp instead of 15, not modeled as a separate variant here). Duration is 2 perc/szint in the
/// book; level-1 baseline (12 rounds) shown, not level-scaled. Purely a visual illusion, no stat
/// changes.
/// </summary>
public sealed class ShapeChange : ISpell
{
    public string Name => "Shape change";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 15;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 12;

    public int GetDamage() => 0;
}
