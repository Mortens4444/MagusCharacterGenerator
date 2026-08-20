using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Psi.Disciplines.General;

/// <summary>
/// Ébredés (Ébresztés) (Általános Diszciplína, p.118). Lets the user program themselves to wake
/// at a set time or external cue without any outside help. Doesn't work if unconscious, drugged
/// asleep, or mentally incapacitated. No stated duration (lasts until the trigger fires); no
/// stated Psi-point cost beyond the book's universal "at least 1 Pp" minimum.
/// </summary>
public sealed class SelfWaking : IPsiDiscipline
{
    public string Name => "Self-waking";

    public int? Power => null;

    public int PsiPointCost => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Mental;

    public int CastingTimeInSegments => 10;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
