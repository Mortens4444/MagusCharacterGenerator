using M.A.G.U.S.Extensions;
using M.A.G.U.S.GameSystem.Psi;
using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Scientific.Psi;

public class PsiJann() : Qualification(QualificationLevel.Master, 1), IPsi
{
    public PsiKind PsiKind => PsiKind.Jann;

    public override string Name => "Psi, Jann";

    public override int QpToBaseQualification => 10;

    public override int QpToMasterQualification => 55;

    public override string ImageName => "psi.png";
}
