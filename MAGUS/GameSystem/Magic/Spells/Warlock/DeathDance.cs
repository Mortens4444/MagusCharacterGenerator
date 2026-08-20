using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Magic.Spells.Warlock;

/// <summary>
/// Haláltánc (Boszorkánymester — Asztrálmágia, Első Törvénykönyv p.255). Forces the victim into a
/// frenzied dance draining 1 Fp per round while repeated Stamina checks eventually kill them (25
/// failures); simplified to a flat 1 Fp/round drain, the repeated-check death mechanic isn't
/// modeled.
/// </summary>
public sealed class DeathDance : ISpell
{
    public string Name => "Death dance";

    public MagicSchool School => MagicSchool.Warlock;

    public int? Power => 5;

    public int ManaCost => 15;

    public int PowerBonusPerManaPoint => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 90;

    public int GetDamage() => 1;
}
