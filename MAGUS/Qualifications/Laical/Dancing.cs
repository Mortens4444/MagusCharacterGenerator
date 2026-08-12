using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Laical;

public class Dancing(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level), ILaicalQualification
{
    public override int QpToBaseQualification => 5;

    public override int QpToMasterQualification => 30;

    public Dancing() : this(QualificationLevel.Base) { }
}
