using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Mágia felfedezése (Boszorkány — Alapvarázslatok, Első Törvénykönyv p.202). Lets the witch
/// sense the presence of any type of magic within 20 láb, whether its source is an object, a
/// person, or a place. Duration is 1 kör/szint; level-1 baseline shown, not level-scaled.
/// </summary>
public sealed class SenseMagic : ISpell
{
    public string Name => "Sense magic";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => null;

    public int ManaCost => 1;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 10;

    public int GetDamage() => 0;
}
