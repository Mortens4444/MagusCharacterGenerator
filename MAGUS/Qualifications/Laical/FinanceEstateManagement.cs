using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Laical;

public class FinanceEstateManagement(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level), IScientificQualification
{
    public override string Name => "Finance / estate management";

    public override int QpToBaseQualification => 10;

    public override int QpToMasterQualification => 30;

    public FinanceEstateManagement() : this(QualificationLevel.Base) { }
}
