using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Szólító ige (Boszorkány — Szimpatikus Mágia, Első Törvénykönyv p.228). Requires a sympathetic
/// object from the target; compels them to travel to the witch's location. Duration lasts until
/// the target arrives, plus 12 more hours; approximated as instantaneous (DurationInRounds 1)
/// since the travel-compulsion mechanic isn't modeled.
/// </summary>
public sealed class SummoningWord : ISpell
{
    public string Name => "Summoning word";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 15;

    public int ManaCost => 45;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 30;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
