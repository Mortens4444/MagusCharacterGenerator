using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Combat;

public class Aiming(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1)
    : Qualification(qualificationLevel, level)
{
    public override int QpToBaseQualification => 20;

    public override int QpToMasterQualification => 35;

    public Aiming() : this(QualificationLevel.Base) { }
}
