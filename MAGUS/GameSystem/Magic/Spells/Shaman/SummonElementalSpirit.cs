using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Szólítás - Asztrál-, Mentálszellemek (Sámán, Második Törvénykönyv p.118, Idézőmágia). Summons
/// an Astral or Mental elemental (what shamans call a "szellem") through Szellemtánc; the shaman
/// only picks the plane, not the species. The summoned creature follows telepathically-sent
/// instructions for 4 minutes per caster level before returning to its own plane. Book cost is
/// 15 Mp + 1 FP (trance) + 2d6+7 FP; the flat 15 Mp + 1 FP baseline is used here, the random FP surcharge
/// left unmodeled. This codebase has no elemental-summoning/AI subsystem for an autonomously
/// acting servant creature; this class exists only as a spellbook/catalog entry with no simulated
/// mechanical effect, mirroring how Warlock's undead-summoning spells are handled.
/// </summary>
public sealed class SummonElementalSpirit : ISpell
{
    public string Name => "Summon elemental spirit";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 15;

    public int PainTolerancePointCost => 1;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 60;

    public int DurationInRounds => 24;

    public int GetDamage() => 0;
}
