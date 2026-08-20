using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Madártávlat (Boszorkány — Térmágia, Első Törvénykönyv p.230). Lets the witch see through a
/// nearby bird's eyes. Costs 15 total (not modeled as a separate tier) to also steer the bird.
/// </summary>
public sealed class BirdsEyeView : ISpell
{
    public string Name => "Bird's-eye view";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => null;

    public int ManaCost => 10;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 5;

    public int DurationInRounds => 60;

    public int GetDamage() => 0;
}
