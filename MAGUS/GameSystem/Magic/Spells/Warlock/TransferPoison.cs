using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Méreg átadása (Boszorkánymester — Méregmágia, Első Törvénykönyv p.253). Transfers a poison
/// already active in the caster's own body into a touched victim, exactly as it was affecting
/// the caster. Book duration is "végleges" (permanent); approximated as a long but finite value.
/// </summary>
public sealed class TransferPoison : ISpell
{
    public string Name => "Transfer poison";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 22;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 2;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;
}
