using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Féltékenység (Boszorkány — Ölelésmágia, Első Törvénykönyv p.224-225). Turns a man violently
/// jealous and overprotective of the witch, controllable to her advantage. Duration is "1
/// óra/szint" in the book; level-1 baseline shown, not level-scaled.
/// </summary>
public sealed class Jealousy : ISpell
{
    public string Name => "Jealousy";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 12;

    public int ManaCost => 7;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 3;

    public int DurationInRounds => 360;

    public int GetDamage() => 0;
}
