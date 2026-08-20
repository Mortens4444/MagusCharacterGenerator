using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Witch;

/// <summary>
/// Retesz (Boszorkány — Misztikus képesség, Első Törvénykönyv p.204). Locks every lock and latch
/// within a 5-láb radius (still openable by hand); handy for trapping uninvited guests.
/// </summary>
public sealed class Lock : ISpell
{
    public string Name => "Lock";

    public MagicSchool School => MagicSchool.Witch;

    public int? Power => null;

    public int ManaCost => 4;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
