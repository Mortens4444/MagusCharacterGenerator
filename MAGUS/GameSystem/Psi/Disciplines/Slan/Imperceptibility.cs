using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Psi.Disciplines.Slan;

/// <summary>
/// Érzékelhetetlenség (Slan-út, p.124). Freezing motionless, the user becomes undetectable to
/// even the sharpest senses and drops out of Hatodik Érzék's range; can't move, fight, use Psi, or
/// speak while active. Only a Láthatatlanság-észlelés of at least strength 4 can pierce it (Kyr
/// Auraérzékelés cannot). 8 Psi points sustain it for 1 round, scaling linearly.
/// </summary>
public sealed class Imperceptibility : IPsiDiscipline
{
    public string Name => "Imperceptibility";

    public int? Power => null;

    public int PsiPointCost => 8;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
