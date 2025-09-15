using M.A.G.U.S.GameSystem.Psi;
using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Scientific.Psi;

public class PsiKranich : Qualification, IPsi
{
    public PsiKranich(QualificationLevel qualificationLevel = QualificationLevel.Base, byte level = 1)
        : base(qualificationLevel, level)
    {
    }

    public PsiKind PsiKind => PsiKind.Kranich;

    public override string Name => "Psi Kranich";
}
