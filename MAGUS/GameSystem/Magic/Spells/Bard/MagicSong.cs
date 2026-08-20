using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Mágia dala (Bárd — Hangmágia, Első Törvénykönyv p.136). Lets the bard cast a non-song spell
/// disguised as singing, so onlookers only notice the performance. Duration matches the
/// disguised spell's own duration; not independently tracked here.
/// </summary>
public sealed class MagicSong : ISpell
{
    public string Name => "Magic song";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 10;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
