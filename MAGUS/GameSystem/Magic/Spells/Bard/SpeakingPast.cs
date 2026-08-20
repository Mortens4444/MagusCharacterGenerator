using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Beszélő múlt (Bárd — Hangmágia, Első Törvénykönyv p.137). Lets the bard hear the most
/// significant last words of a long-dead person, spoken in their own language.
/// </summary>
public sealed class SpeakingPast : ISpell
{
    public string Name => "Speaking to the past";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => null;

    public int ManaCost => 19;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 60;

    public int DurationInRounds => 90;

    public int GetDamage() => 0;
}
