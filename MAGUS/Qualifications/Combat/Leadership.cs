using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Combat;

public class Leadership(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public override int QpToBaseQualification => 5;

    public override int QpToMasterQualification => 20;

    public Leadership() : this(QualificationLevel.Base) { }
}
