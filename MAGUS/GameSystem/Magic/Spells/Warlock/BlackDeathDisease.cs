using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Fekete halál (Boszorkánymester — Rontás, Első Törvénykönyv p.247). Level 4 disease, blackened
/// skin, coma, and death in most cases; highly contagious to those who touch the victim. This
/// codebase has no disease-progression simulation (severity stages, day/hour timelines,
/// contagion); this class exists only as a spellbook/catalog entry with no simulated mechanical
/// effect.
/// </summary>
public sealed class BlackDeathDisease : ISpell
{
    public string Name => "Black death disease";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 35;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 5;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
