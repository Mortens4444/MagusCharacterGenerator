using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Laical;

public class Acting(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level), ILaicalQualification
{
    public override int QpToBaseQualification => 12;

    public override int QpToMasterQualification => 35;

    public Acting() : this(QualificationLevel.Base) { }
}
