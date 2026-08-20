using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Shaman;

/// <summary>
/// Hívás - Elhunytak lelke (Sámán, Második Törvénykönyv p.120, Idézőmágia). Summons the soul of a
/// named dead person via Szellemtánc and an Áldozat (a white horse, or in some tribes/occasions a
/// person); the shaman only needs the full name of the deceased, not a bone or keepsake. The soul
/// stays invisible but communicable (through the sustained Szellemtánc) for caster level × 1d6
/// minutes before departing to a Külső Sík. Book cost is (3 Mp + 1 FP) + 63 Mp; the flat 66 Mp
/// total is used here. Duration approximated at a 1d6-minute (6-round) baseline, not level-scaled.
/// This codebase has no soul-summoning/spirit-communication subsystem; this class exists only as a
/// spellbook/catalog entry with no simulated mechanical effect.
/// </summary>
public sealed class SummonDepartedSoul : ISpell
{
    public string Name => "Summon departed soul";

    public MagicSchool School => MagicSchool.Shaman;

    public int? Power => null;

    public int ManaCost => 66;

    public int PainTolerancePointCost => 1;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1590;

    public int DurationInRounds => 6;

    public int GetDamage() => 0;
}
