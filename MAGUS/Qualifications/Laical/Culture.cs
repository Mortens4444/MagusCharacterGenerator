using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Laical;

public class Culture(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public Culture() : this(QualificationLevel.Base) { }

    public override int QpToBaseQualification => 2;

    public override int QpToMasterQualification => 30;
}
