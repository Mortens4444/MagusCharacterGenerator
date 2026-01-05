using M.A.G.U.S.GameSystem.Psi;
using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Scientific.Psi;

public class PsiMonk() : Qualification(QualificationLevel.Master, 1), IPsi
{
    public PsiKind PsiKind => PsiKind.Monk;

    public override string Name => "Psi, Monk";

    public override int QpToBaseQualification => 10;

    public override int QpToMasterQualification => 55;
}
