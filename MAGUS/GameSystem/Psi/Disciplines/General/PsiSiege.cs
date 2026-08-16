using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Psi.Disciplines.General;

/// <summary>
/// Pszi-ostrom (Általános Diszciplína, available via any psi method, master-level only per the
/// rulebook). Rulebook: exists specifically to destroy a target's psi shields (Ψ-rombolás
/// destroys a Statikus Pajzs outright if enough psi points are committed; Ψ-bontás whittles down a
/// Dinamikus Pajzs incrementally) rather than dealing damage; no resistance roll applies. This
/// engine doesn't model destroying a shield in one shot vs. draining it, so it's simplified to a
/// flat reduction applied to all four of the target's psi-shield values (permanent, matching the
/// rulebook's "shields don't regenerate on their own" framing) rather than requiring the caster to
/// commit enough points to match the shield's own strength.
/// </summary>
public sealed class PsiSiege : IPsiDiscipline
{
    private const int ShieldReduction = 3;

    public string Name => "Psychic siege";

    public int? Power => null;

    public int PsiPointCost => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;

    public void OnHit(Attacker caster, Attacker target)
    {
        if (target is not Character targetCharacter)
        {
            return;
        }

        targetCharacter.StaticAstralPsiShield = Math.Max(0, targetCharacter.StaticAstralPsiShield - ShieldReduction);
        targetCharacter.StaticMentalPsiShield = Math.Max(0, targetCharacter.StaticMentalPsiShield - ShieldReduction);
        targetCharacter.DynamicAstralPsiShield = Math.Max(0, targetCharacter.DynamicAstralPsiShield - ShieldReduction);
        targetCharacter.DynamicMentalPsiShield = Math.Max(0, targetCharacter.DynamicMentalPsiShield - ShieldReduction);
    }
}
