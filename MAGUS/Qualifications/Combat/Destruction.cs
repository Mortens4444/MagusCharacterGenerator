using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Combat;

public class Destruction(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public override int QpToBaseQualification => 15;

    public override int QpToMasterQualification => 30;

    public Destruction() : this(QualificationLevel.Base) { }
}
