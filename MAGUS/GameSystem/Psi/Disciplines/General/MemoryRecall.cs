using MAGUS.Enums;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Psi.Disciplines.General;

/// <summary>
/// Emlékfelidézés (Általános Diszciplína, p.117-118). Burns a place/text/event into the user's
/// memory with a short meditation so it stays perfectly clear for 3 years afterward (or recalls an
/// already-forgotten memory for 10 rounds, not modeled separately here — the 3-year mode is
/// shown). Master level lets it target another creature. No stated Psi-point cost beyond the
/// book's universal "at least 1 Pp" minimum.
/// </summary>
public sealed class MemoryRecall : IPsiDiscipline
{
    public string Name => "Memory recall";

    public int? Power => null;

    public int PsiPointCost => 1;

    public MagicResistanceType ResistanceType => MagicResistanceType.Astral;

    public int CastingTimeInSegments => 20;

    public int DurationInRounds => 3600;

    public int GetDamage() => 0;
}
