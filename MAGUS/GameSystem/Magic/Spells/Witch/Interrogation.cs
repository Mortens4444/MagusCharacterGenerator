using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Kihallgatás (Boszorkány — Térmágia, Első Törvénykönyv p.229). Lets the witch listen in on a
/// creature she has marked, from unlimited distance. Duration is kör/szint; level-1 baseline
/// shown, not level-scaled. Same branding-mark prerequisite as Observation, not enforced here.
/// </summary>
public sealed class Interrogation : ISpell
{
    public string Name => "Interrogation";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => null;

    public int ManaCost => 4;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 3;

    public int DurationInRounds => 6;

    public int GetDamage() => 0;
}
