using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Szólítás - Szellem (Sámán, Második Törvénykönyv p.118, Idézőmágia). Summons a Necrografia
/// Class VI undead (szellem/specter) through Szellemtánc, obeying the shaman for 3 minutes per
/// caster level. Book cost is 29 Mp + 1 FP (trance) + FP equal to the summoned creature's own ÉP;
/// the flat 29 Mp + 1 FP baseline is used here, the creature-scaled FP surcharge left unmodeled. This
/// codebase has no creature-summoning/AI subsystem for an autonomously acting undead servant; this
/// class exists only as a spellbook/catalog entry with no simulated mechanical effect, mirroring
/// how Warlock's undead-summoning spells are handled.
/// </summary>
public sealed class SummonSpecter : ISpell
{
    public string Name => "Summon specter";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 29;

    public int PainTolerancePointCost => 1;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 160;

    public int DurationInRounds => 18;

    public int GetDamage() => 0;
}
