using M.A.G.U.S.GameSystem.Psi;
using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Scientific.Psi;

public class PsiPyarron : Qualification, IPsi
{
    public PsiPyarron(QualificationLevel qualificationLevel = QualificationLevel.Base, byte level = 1)
        : base(qualificationLevel, level)
    {
    }

    public PsiKind PsiKind => PsiKind.Pyarron;

    public override string Name => "Psi, Pyarron";
}
