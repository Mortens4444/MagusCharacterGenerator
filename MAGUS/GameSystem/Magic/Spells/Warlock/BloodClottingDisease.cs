using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Vérdermesztés (Boszorkánymester — Rontás, Első Törvénykönyv p.250). Level 7 circulatory
/// disease; can be used defensively (faster wound clotting) or offensively (clots blood in the
/// veins, draining combat values toward death). This codebase has no disease-progression
/// simulation (severity stages, day/hour timelines, contagion); this class exists only as a
/// spellbook/catalog entry with no simulated mechanical effect.
/// </summary>
public sealed class BloodClottingDisease : ISpell
{
    public string Name => "Blood clotting disease";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 32;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 5;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
