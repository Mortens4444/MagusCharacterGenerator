using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Combat;

public class Bloodlust(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public override int QpToBaseQualification => 8;

    public override int QpToMasterQualification => 15;

    public Bloodlust() : this(QualificationLevel.Base) { }
}
