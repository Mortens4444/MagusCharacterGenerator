using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Jégverés (Boszorkánymester — Természeti Mágia, Első Törvénykönyv p.253). Summons a violent
/// hailstorm over a 1-mile-radius area, ruining crops and travel; requires at least a small rain
/// cloud within sight to grow from. No direct HP damage is given in the book.
/// </summary>
public sealed class Hailstorm : ISpell
{
    public string Name => "Hailstorm";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 45;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 100;

    public int DurationInRounds => 270;

    public int GetDamage() => 0;
}
