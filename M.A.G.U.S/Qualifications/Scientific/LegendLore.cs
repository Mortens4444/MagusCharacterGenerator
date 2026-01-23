using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Scientific;

public class LegendLore(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public override string Name => "Legend lore";

    public override int QpToBaseQualification => 10;

    public override int QpToMasterQualification => 50;

    public LegendLore() : this(QualificationLevel.Base) { }
}
