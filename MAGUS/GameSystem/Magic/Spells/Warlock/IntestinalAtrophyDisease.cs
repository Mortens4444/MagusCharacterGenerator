using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Bélsorvadás (Boszorkánymester — Rontás, Első Törvénykönyv p.246). Level 7 digestive disease;
/// can eventually cause starvation despite eating. This codebase has no disease-progression
/// simulation (severity stages, day/hour timelines, contagion); this class exists only as a
/// spellbook/catalog entry with no simulated mechanical effect.
/// </summary>
public sealed class IntestinalAtrophyDisease : ISpell
{
    public string Name => "Intestinal atrophy disease";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 26;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 5;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
