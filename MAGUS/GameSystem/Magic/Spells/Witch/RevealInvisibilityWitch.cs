using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Láthatatlanság felfedezése (Boszorkány — Mentálmágia, Első Törvénykönyv p.216). Pinpoints a
/// suspected invisible creature's location by reading its thoughts. Not to be confused with any
/// other school's similarly-named spell — this is the Witch's own version.
/// </summary>
public sealed class RevealInvisibilityWitch : ISpell
{
    public string Name => "Reveal invisibility (witch)";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 3;

    public int ManaCost => 8;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Mental;

    public int CastingTimeInSegments => 2;

    public int DurationInRounds => 72;

    public int GetDamage() => 0;
}
