using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Psi.Disciplines.General;

/// <summary>
/// Telekinézis (Általános Diszciplína, p.120). Moves small objects within line of sight at a
/// walking pace (never fast enough to throw as a weapon or cause injury); 2 Psi points move 1 kg
/// for 1 round, scaling linearly. Works on magical objects too.
/// </summary>
public sealed class Telekinesis : IPsiDiscipline
{
    public string Name => "Telekinesis";

    public int? Power => null;

    public int PsiPointCost => 2;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 1;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
