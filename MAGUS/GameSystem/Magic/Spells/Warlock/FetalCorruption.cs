using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Magzat megrontása (Boszorkánymester — Nekromancia, Első Törvénykönyv p.261-262). An extremely
/// dark ritual transferring the caster's soul into an unborn male fetus over 1k6+1 days,
/// permanently escaping reincarnation's bounds at the cost of 1 point each of Willpower and Astral
/// per use. Book duration is "maradandó" (permanent); approximated as a long but finite value.
/// This codebase has no controllable-undead-minion or creature-summoning system; this class exists
/// only as a spellbook/catalog entry with no simulated mechanical effect.
/// </summary>
public sealed class FetalCorruption : ISpell
{
    public string Name => "Fetal corruption";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 90;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 600;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;
}
