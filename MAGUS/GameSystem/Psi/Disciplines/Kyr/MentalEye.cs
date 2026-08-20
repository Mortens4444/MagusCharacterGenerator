using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Psi.Disciplines.Kyr;

/// <summary>
/// Mentálszem (Kyr metódus, p.128). Lets the wizard read a target's quality of thought, seeing
/// through their Mentál Pajzs. On a successful Mentális Mágiaellenállás, the wizard only learns a
/// rough impression (sharp mind / average / dull) and whether a "mental thread" links the target to
/// someone else (not who, unless both ends are viewed). On a failed resistance, the wizard learns
/// exact Intelligence and Willpower scores, caste, and Experience Level/Psi-level within ±1. The
/// subject never learns they were read. Psi-point cost confirmed at 5 (not a header field but
/// recoverable from body prose: "a feltüntetett 5-ön felül... 2-vel növeli a diszciplína
/// Erősségét"). Every extra Psi point beyond the base doubles the discipline's strength.
/// </summary>
public sealed class MentalEye : IPsiDiscipline
{
    public string Name => "Mental eye";

    public int? Power => 1;

    public int PsiPointCost => 5;

    public MagicResistanceType ResistanceType => MagicResistanceType.Mental;

    public int CastingTimeInSegments => 5;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
