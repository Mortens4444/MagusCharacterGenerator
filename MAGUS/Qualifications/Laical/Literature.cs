using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Laical;

public class Literature(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level), ILaicalQualification
{
    public override int QpToBaseQualification => 7;

    public override int QpToMasterQualification => 22;

    public Literature() : this(QualificationLevel.Base) { }
}
