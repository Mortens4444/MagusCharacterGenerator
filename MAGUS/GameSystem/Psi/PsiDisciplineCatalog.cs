using MAGUS.GameSystem.Psi.Disciplines.AntientWay;
using MAGUS.GameSystem.Psi.Disciplines.Jann;
using MAGUS.GameSystem.Psi.Disciplines.Krannish;
using MAGUS.GameSystem.Psi.Disciplines.Kyr;
using MAGUS.GameSystem.Psi.Disciplines.Monk;
using MAGUS.GameSystem.Psi.Disciplines.Pyarron;
using MAGUS.GameSystem.Psi.Disciplines.Slan;
using MAGUS.Interfaces;

namespace MAGUS.GameSystem.Psi;

public static class PsiDisciplineCatalog
{
    public static readonly IReadOnlyList<IPsiDiscipline> All =
    [
        new SpiritLash(),
        new InnerFistStrike(),
        new WillCrush(),
        new PsychicLance(),
        new TelekineticStrike(),
        new MindBlast(),
        new WarhoundFury()
    ];

    public static IEnumerable<IPsiDiscipline> GetAvailable(Character character) =>
        character.Psi == null ? [] : All.Where(discipline => discipline.PsiKind == character.Psi.PsiKind);
}
