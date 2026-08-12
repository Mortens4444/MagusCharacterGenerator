using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Combat;

public class Fistfight(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public override int QpToBaseQualification => 3;

    public override int QpToMasterQualification => 15;

    public Fistfight() : this(QualificationLevel.Base) { }
}
