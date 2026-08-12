using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Scientific;

public class HumanInsight(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level), IScientificQualification
{
    public override string Name => "Human insight";

    public override int QpToBaseQualification => 7;

    public override int QpToMasterQualification => 22;

    public HumanInsight() : this(QualificationLevel.Base) { }
}
