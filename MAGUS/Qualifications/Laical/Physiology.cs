using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Laical;

public class Physiology(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level), IScientificQualification
{
    public override int QpToBaseQualification => 8;

    public override int QpToMasterQualification => 25;

    public Physiology() : this(QualificationLevel.Base) { }
}
