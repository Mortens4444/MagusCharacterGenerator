using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Psi.Disciplines.General;

/// <summary>
/// Hatodik Érzék (Általános Diszciplína, alapfok only — no master form, p.119). Grants vague
/// good/bad premonitions about events during its duration; never gives specifics, only warns that
/// something is coming (and removes Surprise if the premonition was about an impending attack).
/// </summary>
public sealed class SixthSense : IPsiDiscipline
{
    public string Name => "Sixth sense";

    public int? Power => null;

    public int PsiPointCost => 5;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 5;

    public int DurationInRounds => 60;

    public int GetDamage() => 0;
}
