using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Bűbáj (Boszorkány — Asztrálmágia, Első Törvénykönyv p.209). Makes a touched humanoid into a
/// loose friend/helper for the duration; broken instantly by any hostile act toward them. Duration
/// is "1 óra/szint" in the book; level-1 baseline shown, not level-scaled.
/// </summary>
public sealed class Charm : ISpell
{
    public string Name => "Charm";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => 4;

    public int ManaCost => 4;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 360;

    public int GetDamage() => 0;
}
