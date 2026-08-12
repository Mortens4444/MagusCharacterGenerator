using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Scientific;

public class Spellcasting(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level), IScientificQualification
{
    public override int QpToBaseQualification => 15;

    public override int QpToMasterQualification => 45;

    public Spellcasting() : this(QualificationLevel.Base) { }
}
