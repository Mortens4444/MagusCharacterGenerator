using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Szépség elorzása (Boszorkánymester — Vérmágia + Nekromancia, Első Törvénykönyv p.262). Duration
/// is óra/szint in the book; level-1 baseline shown, not level-scaled. Self-buff (bathes in blood
/// to steal victims' beauty); not wired into the enemy-targeting combat pipeline.
/// </summary>
public sealed class StealBeauty : ISpell
{
    public string Name => "Steal beauty";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => null;

    public int ManaCost => 22;

    public int PowerBonusPerManaPoint => 0;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 3600;

    public int DurationInRounds => 360;

    public int GetDamage() => 0;
}
