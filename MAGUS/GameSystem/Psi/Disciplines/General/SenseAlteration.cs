using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Psi.Disciplines.General;

/// <summary>
/// Érzékélesítés (Tompítás és Megzavarás) (Általános Diszciplína, p.118-119). Sharpens, dulls, or
/// scrambles one of the five senses (alapfok on self only) for 1 round per 2 Psi points spent per
/// sense. Book explicitly forbids using it to cause real harm (e.g. can't raise heat-sense enough
/// to cause Fp loss), hence no damage.
/// </summary>
public sealed class SenseAlteration : IPsiDiscipline
{
    public string Name => "Sense alteration";

    public int? Power => null;

    public int PsiPointCost => 2;

    public MagicResistanceType ResistanceType => MagicResistanceType.Mental;

    public int CastingTimeInSegments => 20;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
