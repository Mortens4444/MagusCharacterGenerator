using M.A.G.U.S.GameSystem.Psi;
using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Scientific.Psi;

public class PsiKranic(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level), IPsi
{
    public PsiKind PsiKind => PsiKind.Kranich;

    public override int QpToBaseQualification => 10;

    public override int QpToMasterQualification => 55;

    public override string Name => "Psi, Kranich";
}
