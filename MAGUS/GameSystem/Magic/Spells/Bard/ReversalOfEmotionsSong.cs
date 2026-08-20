using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Bard;

/// <summary>
/// Ellentétek dala (Bárd — Dalmágia, Első Törvénykönyv p.134). One of the bard's strongest
/// emotional songs: flips every strong emotion the target feels into its opposite (love to
/// hatred, fear to courage, and so on) if their resistance fails. Purely narrative effect; no
/// combat mechanic modeled. Book duration is "végleges" (permanent); approximated here as a long
/// but finite DurationInRounds since the interface has no permanence concept.
/// </summary>
public sealed class ReversalOfEmotionsSong : ISpell
{
    public string Name => "Reversal of emotions song";

    public MagicSchool School => MagicSchool.Bard;

    public int? Power => 25;

    public int ManaCost => 35;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 60;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;
}
