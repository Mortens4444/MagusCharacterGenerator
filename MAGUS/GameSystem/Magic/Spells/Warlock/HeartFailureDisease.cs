using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Szívbénítás (Boszorkánymester — Rontás, Első Törvénykönyv p.249). Level 5 disease that stops
/// the heart, leading to unconsciousness and death without prompt healing. This codebase has no
/// disease-progression simulation (severity stages, day/hour timelines, contagion); this class
/// exists only as a spellbook/catalog entry with no simulated mechanical effect.
/// </summary>
public sealed class HeartFailureDisease : ISpell
{
    public string Name => "Heart failure disease";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 70;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 5;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
