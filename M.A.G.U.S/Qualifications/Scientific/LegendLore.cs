using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Scientific;

public class LegendLore(QualificationLevel qualificationLevel = QualificationLevel.Base, byte level = 1) : Qualification(qualificationLevel, level)
{
    public override string Name => "Legend lore";

    public override byte QpToBaseQualification => 10;

    public override byte QpToMasterQualification => 50;
}
