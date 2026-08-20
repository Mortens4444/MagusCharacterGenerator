using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Méreg semlegesítése (Boszorkánymester — Méregmágia, Első Törvénykönyv p.253). Neutralizes any
/// poison in a chosen creature's body, stopping further effects immediately (though it doesn't
/// undo damage already dealt — that needs healing magic). Book duration is "maradandó"
/// (permanent); approximated as a long but finite value.
/// </summary>
public sealed class NeutralizePoison : ISpell
{
    public string Name => "Neutralize poison";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 18;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;
}
