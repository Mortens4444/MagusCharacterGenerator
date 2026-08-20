using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Érzelem átirányítás (Boszorkány — Asztrálmágia, Első Törvénykönyv p.212). Redirects the target
/// of one of the victim's existing emotions toward the witch instead, without changing its
/// intensity or polarity. Book duration lasts until the victim becomes disillusioned (could be
/// minutes or years); approximated here as a long but finite value. Instant one-time change, not
/// modeled as an ongoing effect.
/// </summary>
public sealed class EmotionRedirect : ISpell
{
    public string Name => "Emotion redirection";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 8;

    public int ManaCost => 55;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;
}
