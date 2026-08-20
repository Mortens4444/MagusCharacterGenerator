using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Szépségvarázs (Boszorkány — Alapvarázslatok, Type: Anyagi Mágia, Első Törvénykönyv p.202).
/// Self-only transformation into a beautiful, young version of the witch's own race. Not wired
/// into the enemy-targeting combat pipeline.
/// </summary>
public sealed class BeautyTransformation : ISpell
{
    public string Name => "Beauty transformation";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => null;

    public int ManaCost => 8;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 100;

    public int DurationInRounds => 8640;

    public int GetDamage() => 0;
}
