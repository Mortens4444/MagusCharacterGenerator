using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Psi.Disciplines.General;

/// <summary>
/// Képességjavítás (Rontás) (Általános Diszciplína, p.119-120). Temporarily raises (alapfok, self
/// only) any physical ability except Beauty, up to a cap of 20; costs scale steeply with the size
/// of the change (2/3/4/5/6/8/16/32 Pp for a ±1 through ±8 shift over the base 6-round duration,
/// doubling/tripling for longer). At master level the same mechanism can instead be turned on
/// another creature to reduce an ability (Rontás) — dropping one to 0 or below kills outright, but
/// that offensive use isn't modeled here (flavor-only, self-buff by default). Doc note: only the
/// cheapest ±1 tier's cost is shown as the base PsiPointCost.
/// </summary>
public sealed class AbilityEnhancement : IPsiDiscipline
{
    public string Name => "Ability enhancement";

    public int? Power => null;

    public int PsiPointCost => 2;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 20;

    public int DurationInRounds => 6;

    public int GetDamage() => 0;
}
