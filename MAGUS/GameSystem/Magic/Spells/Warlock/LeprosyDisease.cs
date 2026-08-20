using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Lepra (Boszorkánymester — Rontás, Első Törvénykönyv p.248). Level 6 disease numbing the
/// extremities and draining physical abilities over time. This codebase has no disease-progression
/// simulation (severity stages, day/hour timelines, contagion); this class exists only as a
/// spellbook/catalog entry with no simulated mechanical effect.
/// </summary>
public sealed class LeprosyDisease : ISpell
{
    public string Name => "Leprosy disease";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 40;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 5;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
