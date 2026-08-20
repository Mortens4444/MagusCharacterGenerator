using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Bűvragály (Boszorkánymester — Rontás, Első Törvénykönyv p.246). Makes a Rontás disease
/// contagious, spreading it through touch to a number of further victims based on caster level,
/// each generation one severity level weaker; Mana cost in the book is 20 plus the base disease's
/// own cost, base cost shown here. This codebase has no disease-progression simulation (severity
/// stages, day/hour timelines, contagion); this class exists only as a spellbook/catalog entry
/// with no simulated mechanical effect.
/// </summary>
public sealed class MagicPlague : ISpell
{
    public string Name => "Magic plague";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 20;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 5;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
