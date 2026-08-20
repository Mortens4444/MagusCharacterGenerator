using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Sorvasztás (Boszorkány — Ölelésmágia, Első Törvénykönyv p.226). Compels the victim to
/// obsessively serve the witch, at 3 Egészség (Health) points lost per encounter, transferred to
/// the witch. Book duration is "speciális" (lasts until the relationship ends or the victim
/// dies); approximated as a long but finite value.
/// </summary>
public sealed class Withering : ISpell
{
    public string Name => "Withering";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 15;

    public int ManaCost => 22;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Mental;

    public int CastingTimeInSegments => 5;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;
}
