using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Vörös halál (Boszorkánymester — Rontás, Első Törvénykönyv p.250-251). Level 3 magical
/// circulatory disease causing fatal bleeding through the pores; cannot be healed even by
/// priestly magic. This codebase has no disease-progression simulation (severity stages,
/// day/hour timelines, contagion); this class exists only as a spellbook/catalog entry with no
/// simulated mechanical effect.
/// </summary>
public sealed class RedDeathDisease : ISpell
{
    public string Name => "Red death disease";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 45;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 5;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
