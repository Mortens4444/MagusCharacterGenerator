using MAGUS.GameSystem.Psi;
using MAGUS.GameSystem.Qualifications;
using MAGUS.Interfaces;

namespace MAGUS.Qualifications.Scientific.Psi;

public class PsiAntientWay(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level), IPsi, INotForLearn
{
    public PsiKind PsiKind => PsiKind.AntientWay;

    public override string Name => "Psi, Antient way";

    public override int QpToBaseQualification => 10;

    public override int QpToMasterQualification => 55;

    public override string[] Images => ["psi.png"];

    public PsiAntientWay() : this(QualificationLevel.Base) { }
}
