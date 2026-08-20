using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Tüdősorvadás (Boszorkánymester — Rontás, Első Törvénykönyv p.249). Level 6 disease with a long
/// incubation period that reduces lung capacity, draining Strength/Speed/Intelligence and combat
/// values. This codebase has no disease-progression simulation (severity stages, day/hour
/// timelines, contagion); this class exists only as a spellbook/catalog entry with no simulated
/// mechanical effect.
/// </summary>
public sealed class LungAtrophyDisease : ISpell
{
    public string Name => "Lung atrophy disease";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 12;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 5;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
