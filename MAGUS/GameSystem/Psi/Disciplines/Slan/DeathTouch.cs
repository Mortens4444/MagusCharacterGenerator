using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Psi.Disciplines.Slan;

/// <summary>
/// Halálos Ujj (Slan-út). Rulebook: a touch attack requiring a successful attack roll in combat;
/// no resistance roll of any kind applies (hence Power is null), armor doesn't reduce it, and it
/// cannot be cured. Damage is normally delayed up to 24 hours at the caster's choosing and scales
/// 1:1 with the caster's experience level at a flat 3 psi points per point of damage (level 1 = 1
/// damage for 3 points, level 2 = 2 damage for 6 points, etc). This engine resolves attacks
/// immediately within the current round rather than modeling a delayed, chosen-moment trigger, so
/// this is simplified to the level-1 baseline: a flat 1 point of guaranteed damage for 3 psi
/// points, rather than scaling with the caster's actual level.
/// </summary>
public sealed class DeathTouch : IPsiDiscipline
{
    public string Name => "Death touch";

    public int? Power => null;

    public int PsiPointCost => 3;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 1;

    public int GetDamage() => 1;
}
