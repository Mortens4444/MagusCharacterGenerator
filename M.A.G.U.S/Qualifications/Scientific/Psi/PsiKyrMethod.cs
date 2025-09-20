using M.A.G.U.S.GameSystem.Psi;
using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Scientific.Psi;

public class PsiKyrMethod : Qualification, IPsi
{
    public PsiKyrMethod()
        : base(QualificationLevel.Master, 1)
    {
    }

    public PsiKind PsiKind => PsiKind.Kyr;

    public override string Name => "Psi, Kyr method";
}
