using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Útkeresés (Boszorkány — Misztikus képesség, Első Törvénykönyv p.204). Reveals only the
/// direction toward a desired destination, not the route or distance; can also point out a
/// compass heading.
/// </summary>
public sealed class PathFinding : ISpell
{
    public string Name => "Path finding";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => null;

    public int ManaCost => 7;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
