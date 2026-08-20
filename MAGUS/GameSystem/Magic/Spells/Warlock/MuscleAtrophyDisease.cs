using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Izomsorvadás (Boszorkánymester — Rontás, Első Törvénykönyv p.247). Level 4 muscular disease
/// draining Strength and Speed each round until treated. This codebase has no disease-progression
/// simulation (severity stages, day/hour timelines, contagion); this class exists only as a
/// spellbook/catalog entry with no simulated mechanical effect.
/// </summary>
public sealed class MuscleAtrophyDisease : ISpell
{
    public string Name => "Muscle atrophy disease";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 35;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 5;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
