using M.A.G.U.S.GameSystem.Psi;
using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Scientific.Psi;

public class PsiJann() : Qualification(QualificationLevel.Master, 1), IPsi
{
    public PsiKind PsiKind => PsiKind.Jann;

    public override string Name => "Psi, Jann";

    public override int QpToBaseQualification => Int32.MaxValue;

    public override int QpToMasterQualification => Int32.MaxValue;

    public override string[] Images => ["psi.png"];
}
