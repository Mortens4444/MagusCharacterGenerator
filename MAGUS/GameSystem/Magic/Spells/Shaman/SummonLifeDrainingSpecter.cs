using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Szólítás - Életerővel táplálkozó szellem (Sámán, Második Törvénykönyv p.118-119, Idézőmágia).
/// Summons a Necrografia Class VII undead (a life-force-feeding spirit) through Szellemtánc,
/// obeying the shaman for 2 minutes per caster level. Book cost is 37 Mp + 1 FP (trance) + FP equal
/// to the summoned creature's own ÉP; the flat 37 Mp baseline is used here, the creature-scaled FP
/// surcharge left unmodeled. This codebase has no creature-summoning/AI subsystem for an
/// autonomously acting undead servant; this class exists only as a spellbook/catalog entry with no
/// simulated mechanical effect, mirroring how Warlock's undead-summoning spells are handled.
/// </summary>
public sealed class SummonLifeDrainingSpecter : ISpell
{
    public string Name => "Summon life-draining specter";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 37;

    public int PainTolerancePointCost => 1;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 180;

    public int DurationInRounds => 12;

    public int GetDamage() => 0;
}
