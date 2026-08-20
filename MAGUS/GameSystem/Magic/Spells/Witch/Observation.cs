using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Megfigyelés (Boszorkány — Térmágia, Mentálmágia, Első Törvénykönyv p.229). Lets the witch see
/// through the eyes of a creature she has marked. Duration is kör/szint; level-1 baseline shown,
/// not level-scaled. Only works on a creature already marked with Megbélyegzés csókja (Mark of
/// branding); that prerequisite isn't enforced here.
/// </summary>
public sealed class Observation : ISpell
{
    public string Name => "Observation";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => null;

    public int ManaCost => 5;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 3;

    public int DurationInRounds => 6;

    public int GetDamage() => 0;
}
