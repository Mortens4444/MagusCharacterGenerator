using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Élő történelem (Bárd — Fénymágia, Első Törvénykönyv p.148). Like Képidézés, but replays up to
/// three past moments (from the bard's memory of an object, place, or building) as silent moving
/// pictures visible to everyone present. Duration is 1 perc/szint in the book; level-1 baseline
/// shown, not level-scaled.
/// </summary>
public sealed class LivingHistory : ISpell
{
    public string Name => "Living history";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 21;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 60;

    public int DurationInRounds => 60;

    public int GetDamage() => 0;
}
