using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Laical;

public class Riding(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level), ILaicalQualification
{
    public override int QpToBaseQualification => 1;

    public override int QpToMasterQualification => 15;

    public Riding() : this(QualificationLevel.Base) { }
}
