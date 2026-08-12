using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Scientific;

public class Herbalism(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level), IScientificQualification
{
    public override int QpToBaseQualification => 5;

    public override int QpToMasterQualification => 35;

    public Herbalism() : this(QualificationLevel.Base) { }
}
