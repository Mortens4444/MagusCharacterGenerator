using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Lebegés vízben (Boszorkány — Misztikus képesség, Első Törvénykönyv p.205). Lets the witch
/// float effortlessly on the surface of even the roughest water, supporting her own weight plus
/// 25 kg.
/// </summary>
public sealed class WaterWalking : ISpell
{
    public string Name => "Water walking";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => null;

    public int ManaCost => 2;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 60;

    public int GetDamage() => 0;
}
