using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Szólítás - Lidércek (Sámán, Második Törvénykönyv p.117-118, Idézőmágia). Summons a
/// Necrografia Class V undead (lidérc/wraith) through Szellemtánc, which then obeys the shaman's
/// commands for 4 minutes per caster level before vanishing. Book cost is 21 Mp + 1 FP (for the
/// trance) + FP equal to the summoned creature's own ÉP (e.g. a Fantom costs 21 Mp + 33 FP); the
/// flat 21 Mp baseline is used here, the creature-scaled FP surcharge left unmodeled. This
/// codebase has no creature-summoning/AI subsystem for an autonomously acting undead servant (it
/// has no stat block for a "lidérc" to instantiate); this class exists only as a spellbook/catalog
/// entry with no simulated mechanical effect, mirroring how Warlock's undead-summoning spells
/// (e.g. MagicPlague, SummonUndead) are handled.
/// </summary>
public sealed class SummonWraith : ISpell
{
    public string Name => "Summon wraith";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 21;

    public int PainTolerancePointCost => 1;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 140;

    public int DurationInRounds => 24;

    public int GetDamage() => 0;
}
