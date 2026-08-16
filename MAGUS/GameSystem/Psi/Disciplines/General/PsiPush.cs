using MAGUS.Enums;
using MAGUS.GameSystem.CombatModifiers;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Psi.Disciplines.General;

/// <summary>
/// Pszi-lökés (Általános Diszciplína, available via any psi method). Rulebook: not a
/// damage-dealing effect at all — it manifests as a directable gust of force (1 kg of push per psi
/// point spent, no fixed cap) used to knock over objects or unbalance a target; no resistance
/// roll applies, and it has no stated duration. This engine has no positioning/knockback system to
/// model "pushed back", so it's represented instead as briefly knocking the target off balance:
/// a flat Defense value penalty for the rest of the round (cleared at round end, see
/// CombatEngine.ProcessAssignmentTurnAsync), rather than scaling with psi points spent.
/// </summary>
public sealed class PsiPush : IPsiDiscipline
{
    private const int DefenseValuePenalty = 5;

    public string Name => "Psychic push";

    public int? Power => null;

    public int PsiPointCost => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;

    public void OnHit(Attacker caster, Attacker target)
    {
        target.AddTemporaryModifier(new CombatModifier { DefenseValue = -DefenseValuePenalty });
    }
}
