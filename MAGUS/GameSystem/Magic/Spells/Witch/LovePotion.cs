using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Szerelem itala (Boszorkány — Bájitalok, Első Törvénykönyv p.233). Requires a sympathetic
/// object from the intended target mixed in while brewing; the drinker falls permanently in love
/// with that specific person rather than a random one. Book resistance is a fixed 50E, not scaled
/// by caster level — shown as a flat Power 50.
/// </summary>
public sealed class LovePotion : ISpell
{
    public string Name => "Love potion";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 50;

    public int ManaCost => 60;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;
}
