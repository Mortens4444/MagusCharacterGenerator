using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Mágikus hang (Bárd — Hangmágia, Első Törvénykönyv p.137). Creates an invisible sound source
/// that stores up to 25 words (or music) and speaks them only once a bard-chosen trigger
/// condition is met. Book duration is "végleges" (permanent, waits indefinitely for its trigger
/// condition); approximated as a long but finite value.
/// </summary>
public sealed class MagicVoice : ISpell
{
    public string Name => "Magic voice";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 8;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;
}
