using M.A.G.U.S.GameSystem.Psi.Disciplines.AntientWay;
using M.A.G.U.S.GameSystem.Psi.Disciplines.Jann;
using M.A.G.U.S.GameSystem.Psi.Disciplines.Krannish;
using M.A.G.U.S.GameSystem.Psi.Disciplines.Kyr;
using M.A.G.U.S.GameSystem.Psi.Disciplines.Monk;
using M.A.G.U.S.GameSystem.Psi.Disciplines.Pyarron;
using M.A.G.U.S.GameSystem.Psi.Disciplines.Slan;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.GameSystem.Psi;

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
