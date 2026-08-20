using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Csontészlelés (Boszorkánymester — Nekromancia, Első Törvénykönyv p.261). Detects the buried
/// remains of deceased evil creatures within a 150-láb radius (up to 12 láb deep), revealing their
/// race and former power. This codebase has no controllable-undead-minion or creature-summoning
/// system; this class exists only as a spellbook/catalog entry with no simulated mechanical effect.
/// </summary>
public sealed class BoneDetection : ISpell
{
    public string Name => "Bone detection";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 5;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 50;

    public int DurationInRounds => 60;

    public int GetDamage() => 0;
}
