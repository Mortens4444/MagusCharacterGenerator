using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Hangtanulmány (Bárd — Hangmágia, Első Törvénykönyv p.138). Lets the bard study a voice's
/// pitch, volume, and timbre for later mimicry (feeds into Hangutánzás). Book duration is
/// "végleges" (permanent); approximated as a long but finite value.
/// </summary>
public sealed class VoiceStudy : ISpell
{
    public string Name => "Voice study";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 2;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 180;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;
}
