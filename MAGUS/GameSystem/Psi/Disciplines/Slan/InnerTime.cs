using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Psi.Disciplines.Slan;

/// <summary>
/// Belső Idő (Slan-út, p.123). Slows the user's subjective time so a single real segment feels
/// like — and grants the actions of — a full round: dodging magical projectiles, plucking arrows
/// from the air, immune to surprise. 10 Psi points slow 1 real segment (20 for 2, etc). Afterward
/// the user must rest for as many rounds as segments experienced, unable to use Psi and suffering
/// -25 to all combat values if forced into anything strenuous during that recovery. Self-only;
/// grants extra actions rather than a combat-value effect, so it's a flavor-only catalog entry
/// here.
/// </summary>
public sealed class InnerTime : IPsiDiscipline
{
    public string Name => "Inner time";

    public int? Power => null;

    public int PsiPointCost => 10;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
