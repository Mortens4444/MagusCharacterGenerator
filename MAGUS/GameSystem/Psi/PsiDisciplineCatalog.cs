using MAGUS.GameSystem.Psi.Disciplines.General;
using MAGUS.GameSystem.Psi.Disciplines.Slan;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Psi;

public static class PsiDisciplineCatalog
{
    // Rulebook (p.117): Slan-út and Kyr-módszer practitioners also get every Általános Diszciplína
    // (at master level from level 1), on top of whatever their own method adds. Every other named
    // school (AntientWay, Monk, Jann, Pyarron, Krannish) uses the Pyarroni módszer, i.e. only the
    // Általános Diszciplínák, just calibrated with different base values per school/culture — those
    // per-school numbers aren't sourced from the rulebook yet, so every school currently shares the
    // same General values until that research is done.
    private static readonly IReadOnlyList<IPsiDiscipline> General =
    [
        new PsiPush(),
        new PsiSiege()
    ];

    private static readonly IReadOnlyList<IPsiDiscipline> SlanOnly = [new DeathTouch()];

    public static IEnumerable<IPsiDiscipline> GetAvailable(Character character)
    {
        if (character.Psi == null)
        {
            return [];
        }

        return character.Psi.PsiKind switch
        {
            PsiKind.Slan => [.. General, .. SlanOnly],
            _ => General
        };
    }
}
