using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Scientific;

public class Heraldry(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level), IScientificQualification
{
    public override int QpToBaseQualification => 5;

    public override int QpToMasterQualification => 15;

    public Heraldry() : this(QualificationLevel.Base) { }
}
