using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Scientific;

public class HistoryLore(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level), IScientificQualification
{
    public override string Name => "History lore";

    public override int QpToBaseQualification => 5;

    public override int QpToMasterQualification => 20;

    public HistoryLore() : this(QualificationLevel.Base) { }
}
