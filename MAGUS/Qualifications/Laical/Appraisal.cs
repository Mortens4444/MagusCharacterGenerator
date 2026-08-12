using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Laical;

public class Appraisal(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level), ILaicalQualification
{
    public override int QpToBaseQualification => 5;

    public override int QpToMasterQualification => 11;

    public Appraisal() : this(QualificationLevel.Base) { }
}
