using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Hívás - Alsórendű démonok (Sámán, Második Törvénykönyv p.119-120, Idézőmágia). Summons a demon
/// through Szellemtánc and an Áldozat (sacrifice, paid partly from the shaman's own life force);
/// the summoned demon obeys completely, with no warding/binding circle needed. The book scales this
/// one rite across demon power tiers by ÉP: lesser demons cost (3 Mp + 1 FP) + 47 Mp total, while
/// demons over 20 ÉP ("démonhercegek"/demon princes) cost up to 98 Mp plus a much larger sacrifice
/// (with most shamans only managing it with a Gyógyító amulett's stored life force). The base
/// 50 Mp figure (rounding the lesser-demon total) is used here; the ÉP-tiered cost scaling and
/// life-force sacrifice cost are left unmodeled. Duration is 4 minutes per caster level for lesser
/// demons (demon princes follow for caster-level-many rolls of k3 minutes instead); level-1
/// baseline used. This codebase has no demon-summoning/AI subsystem for an autonomously acting
/// demon servant; this class exists only as a spellbook/catalog entry with no simulated mechanical
/// effect, mirroring how Warlock's undead-summoning spells (e.g. MagicPlague, SummonUndead) are
/// handled.
/// </summary>
public sealed class SummonDemon : ISpell
{
    public string Name => "Summon demon";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 50;

    public int PainTolerancePointCost => 1;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1610;

    public int DurationInRounds => 24;

    public int GetDamage() => 0;
}
