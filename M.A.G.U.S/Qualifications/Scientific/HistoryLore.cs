using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Scientific;

public class HistoryLore(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public override string Name => "History lore";

    public override int QpToBaseQualification => 5;

    public override int QpToMasterQualification => 20;

    public HistoryLore() : this(QualificationLevel.Base) { }
}
