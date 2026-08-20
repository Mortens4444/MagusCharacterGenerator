using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Távolság dala (Bárd — Hangmágia, Első Törvénykönyv p.136). Amplifies a song-type spell's
/// range two-, three-, or fourfold. Duration matches the amplified song's own duration; not
/// independently tracked here.
/// </summary>
public sealed class SongRangeAmplification : ISpell
{
    public string Name => "Song range amplification";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 10;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
