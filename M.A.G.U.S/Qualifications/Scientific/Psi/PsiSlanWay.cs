using M.A.G.U.S.GameSystem.Psi;
using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Scientific.Psi;

public class PsiSlanWay : Qualification, IPsi
{
    public PsiSlanWay()
        : base(QualificationLevel.Master, 1)
    {
    }

    public PsiKind PsiKind => PsiKind.Slan;

    public override string Name => "Psi, Slan way";
}
