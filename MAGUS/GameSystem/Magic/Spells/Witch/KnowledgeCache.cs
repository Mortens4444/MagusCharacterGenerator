using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Tudástár (Boszorkány — Ölelésmágia, Első Törvénykönyv p.225-226). Book duration is
/// "speciális" — permanently learned knowledge/an ongoing skill boost; approximated as a long
/// but finite value. Two use-modes (permanently learn a sexual-technique skill from a more
/// experienced partner, or temporarily perform beyond one's own trained skill level) aren't
/// distinguished here.
/// </summary>
public sealed class KnowledgeCache : ISpell
{
    public string Name => "Knowledge cache";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => null;

    public int ManaCost => 7;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 3;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;
}
