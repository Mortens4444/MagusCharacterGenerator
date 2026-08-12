using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Laical;

public class Torture(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level), ILaicalQualification
{
    public override int QpToBaseQualification => 2;

    public override int QpToMasterQualification => 15;

    public Torture() : this(QualificationLevel.Base) { }
}
