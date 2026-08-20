using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Fájdalom (Boszorkánymester — Rontás, Első Törvénykönyv p.247). Level 1 nervous-system disease
/// causing crippling ongoing pain damage until healed or death. This codebase has no
/// disease-progression simulation (severity stages, day/hour timelines, contagion); this class
/// exists only as a spellbook/catalog entry with no simulated mechanical effect.
/// </summary>
public sealed class PainDisease : ISpell
{
    public string Name => "Pain disease";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 7;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 5;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
