using MAGUS.GameSystem.Psi;
using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Scientific.Psi;

public class PsiMonk() : Qualification(QualificationLevel.Master, 1), IPsi
{
    public PsiKind PsiKind => PsiKind.Monk;

    public override string Name => "Psi, Monk";

    public override int QpToBaseQualification => 10;

    public override int QpToMasterQualification => 55;

    public override string[] Images => ["psi.png"];
}
