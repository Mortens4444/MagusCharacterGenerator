using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Mágia felfedezése (Boszorkánymester — Alapvarázslatok, Első Törvénykönyv p.240). Senses the
/// presence of any type of magic within 20 láb, whatever its source. Duration is 1 kör/szint in
/// the book; level-1 baseline shown, not level-scaled.
/// </summary>
public sealed class DetectMagicPresence : ISpell
{
    public string Name => "Detect magic presence";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 1;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
