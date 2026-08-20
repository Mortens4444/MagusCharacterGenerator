using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Eredetkutatás (Boszorkány — Misztikus képesség, Első Törvénykönyv p.204). Reveals an object's
/// history by touch — its past owners and the significant events it witnessed. Book casting time
/// is 12 kör plus a k6-hour trance; only the 12 kör shown.
/// </summary>
public sealed class OriginDivination : ISpell
{
    public string Name => "Origin divination";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => null;

    public int ManaCost => 34;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 120;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
