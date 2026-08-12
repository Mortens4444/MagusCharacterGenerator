using MAGUS.GameSystem.Psi;
using MAGUS.GameSystem.Qualifications;
using MAGUS.Interfaces;

namespace MAGUS.Qualifications.Scientific.Psi;

public class PsiJann() : Qualification(QualificationLevel.Master, 1), IPsi, INotForLearn
{
    public PsiKind PsiKind => PsiKind.Jann;

    public override string Name => "Psi, Jann";

    public override int QpToBaseQualification => 10;

    public override int QpToMasterQualification => 55;

    public override string[] Images => ["psi.png"];
}
