using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Psi.Disciplines.Slan;

/// <summary>
/// Jelentéktelenség (Slan-út, p.124-125). Wraps the user in an aura of total unremarkableness —
/// even alert guards look right past them as "just one of us". Broken instantly by speaking or
/// fighting, or defeated by a successful Intelligence check or active mental/astral/Hatodik Érzék
/// detection. Doesn't work in situations with no plausible group to blend into. 6 Psi points
/// sustain it for 1 round, scaling linearly.
/// </summary>
public sealed class Insignificance : IPsiDiscipline
{
    public string Name => "Insignificance";

    public int? Power => null;

    public int PsiPointCost => 6;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
