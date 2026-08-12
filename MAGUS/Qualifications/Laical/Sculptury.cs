using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Laical;

public class Sculptury(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level), ILaicalQualification
{
    public override int QpToBaseQualification => 8;

    public override int QpToMasterQualification => 30;

    public Sculptury() : this(QualificationLevel.Base) { }
}
