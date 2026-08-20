using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Életerő raktározása (Boszorkánymester — Nekromancia, Első Törvénykönyv p.262-263). Drains life
/// force (as in Életerőszívás) into a prepared gemstone instead of the caster, for later release.
/// Book duration is "végleges" (permanent); approximated as a long but finite value. This codebase
/// has no controllable-undead-minion or creature-summoning system; this class exists only as a
/// spellbook/catalog entry with no simulated mechanical effect.
/// </summary>
public sealed class LifeForceStorage : ISpell
{
    public string Name => "Life force storage";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 22;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;
}
