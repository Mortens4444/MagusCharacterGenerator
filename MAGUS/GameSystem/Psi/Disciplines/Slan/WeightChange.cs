using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Psi.Disciplines.Slan;

/// <summary>
/// Testsúlyváltoztatás (Slan-út, p.125). Raises or lowers the user's own body weight (never
/// items carried), letting them leap several stories, run on snow without a trace, or swim
/// faster. Cost scales with the size of the change (1/2/4/7/10/20/30/35 Pp for a 1/3/5/9/13/31/62/
/// 93 kg shift over the base 3-round duration; doubling/tripling the points doubles/triples the
/// duration). Can't exceed triple or drop below a third of the original weight. Doc note: only the
/// cheapest 1 kg tier's cost is shown as the base PsiPointCost.
/// </summary>
public sealed class WeightChange : IPsiDiscipline
{
    public string Name => "Weight change";

    public int? Power => null;

    public int PsiPointCost => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 3;

    public int GetDamage() => 0;
}
