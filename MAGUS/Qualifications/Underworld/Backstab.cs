using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Underworld;

public class Backstab(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public override int QpToBaseQualification => 10;

    public override int QpToMasterQualification => 25;

    public Backstab() : this(QualificationLevel.Base) { }
}
