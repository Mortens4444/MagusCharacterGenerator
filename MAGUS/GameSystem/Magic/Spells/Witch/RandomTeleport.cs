using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Eltűnés (Boszorkány — Térmágia, Első Törvénykönyv p.231). Teleports the witch to a random
/// point within a 10-mile radius (direction and distance rolled randomly per the book);
/// randomization isn't modeled.
/// </summary>
public sealed class RandomTeleport : ISpell
{
    public string Name => "Random teleport";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => null;

    public int ManaCost => 32;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
