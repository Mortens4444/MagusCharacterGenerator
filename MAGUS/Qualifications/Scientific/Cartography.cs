using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Scientific;

public class Cartography(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level), IScientificQualification
{
    public override int QpToBaseQualification => 10;

    public override int QpToMasterQualification => 17;

    public Cartography() : this(QualificationLevel.Base) { }
}
