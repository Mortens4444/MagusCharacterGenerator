using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Psi.Disciplines.Kyr;

/// <summary>
/// Pszi-ostrom (Kyr metódus, p.129). Identical in kind to the General `PsiSiege` discipline (see
/// `MAGUS.GameSystem.Psi.Disciplines.General.PsiSiege`) but stronger: 1 Psi point tears down 2
/// points from a Dinamikus Pajzs (Ψ-bontás), or 2 points of strength (E) from a Statikus Pajzs
/// (Ψ-rombolás), versus the General version's 1-for-1 rate. Named `KyrPsiSiege` to avoid colliding
/// with the General `PsiSiege` class. Simplified the same way as the General version: a flat
/// reduction to all four of the target's psi-shield values rather than requiring the caster to
/// commit enough points to match the Statikus Pajzs's own full strength in one go.
/// </summary>
public sealed class KyrPsiSiege : IPsiDiscipline
{
    private const int ShieldReduction = 6;

    public string Name => "Psychic siege (Kyr)";

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
