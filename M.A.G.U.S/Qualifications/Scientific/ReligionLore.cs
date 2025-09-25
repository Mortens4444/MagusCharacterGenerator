using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Scientific;

public class ReligionLore(QualificationLevel qualificationLevel = QualificationLevel.Base, byte level = 1) : Qualification(qualificationLevel, level)
{
    public override string Name => "Religion lore";

    public override byte QpToBaseQualification => 5;

    public override byte QpToMasterQualification => 25;
}
