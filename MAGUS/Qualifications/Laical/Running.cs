using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Laical;

public class Running(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level), ILaicalQualification
{
    public override int QpToBaseQualification => 9;

    public override int QpToMasterQualification => 24;

    public Running() : this(QualificationLevel.Base) { }
}
