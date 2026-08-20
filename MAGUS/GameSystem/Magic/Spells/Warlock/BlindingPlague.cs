using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Vakság okozás (Boszorkánymester — Rontás, Első Törvénykönyv p.249). Level 4 magical disease
/// that causes temporary blindness once it reaches a critical severity stage. This codebase has
/// no disease-progression simulation (severity stages, day/hour timelines, contagion); this class
/// exists only as a spellbook/catalog entry with no simulated mechanical effect.
/// </summary>
public sealed class BlindingPlague : ISpell
{
    public string Name => "Blinding plague";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 7;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 5;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
