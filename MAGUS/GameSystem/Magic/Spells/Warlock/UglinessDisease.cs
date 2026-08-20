using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Rútság (Boszorkánymester — Rontás, Első Törvénykönyv p.248-249). Level 8 skin disease that
/// reduces the victim's Beauty based on severity. This codebase has no disease-progression
/// simulation (severity stages, day/hour timelines, contagion); this class exists only as a
/// spellbook/catalog entry with no simulated mechanical effect.
/// </summary>
public sealed class UglinessDisease : ISpell
{
    public string Name => "Ugliness disease";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 21;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 5;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
