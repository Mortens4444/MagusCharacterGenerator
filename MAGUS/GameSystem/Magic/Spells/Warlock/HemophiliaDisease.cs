using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Vérzékenység (Boszorkánymester — Rontás, Első Törvénykönyv p.250). Level 6 circulatory disease
/// preventing blood clotting, worsening bleeding from any wound. This codebase has no
/// disease-progression simulation (severity stages, day/hour timelines, contagion); this class
/// exists only as a spellbook/catalog entry with no simulated mechanical effect.
/// </summary>
public sealed class HemophiliaDisease : ISpell
{
    public string Name => "Hemophilia disease";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 43;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 5;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
