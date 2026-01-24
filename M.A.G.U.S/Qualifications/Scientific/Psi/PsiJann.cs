using M.A.G.U.S.GameSystem.Psi;
using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.Qualifications.Scientific.Psi;

public class PsiJann() : Qualification(QualificationLevel.Master, 1), IPsi, INotForLearn
{
    public PsiKind PsiKind => PsiKind.Jann;

    public override string Name => "Psi, Jann";

    public override int QpToBaseQualification => 10;

    public override int QpToMasterQualification => 55;

    public override string[] Images => ["psi.png"];
}
