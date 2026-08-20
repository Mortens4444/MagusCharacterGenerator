using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Psi.Disciplines.General;

/// <summary>
/// Telepátia (Gondolatátvitel) (Általános Diszciplína, master-level only, p.120-121). Lets two
/// psi-users converse or share mental images; the caster must know the recipient perfectly or see
/// them (distance doesn't matter if known). Costs 2 Pp/round if the parties can see each other, or
/// 1 Pp/segment if not; the sender alone pays. The only discipline able to slip past a Statikus
/// Pajzs (a Dinamikus Pajzs still blocks it).
/// </summary>
public sealed class Telepathy : IPsiDiscipline
{
    public string Name => "Telepathy";

    public int? Power => null;

    public int PsiPointCost => 2;

    public MagicResistanceType ResistanceType => MagicResistanceType.Mental;

    public int CastingTimeInSegments => 30;

    public int DurationInRounds => 1;

    public int GetDamage() => 0;
}
