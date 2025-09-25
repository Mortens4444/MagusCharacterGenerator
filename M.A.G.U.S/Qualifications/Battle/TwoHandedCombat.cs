using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Battle;

public class TwoHandedCombat(QualificationLevel qualificationLevel = QualificationLevel.Base, byte level = 1) : Qualification(qualificationLevel,  level)
{
    public override string Name => "Two-handed combat";

    public override byte QpToBaseQualification => 15;

    public override byte QpToMasterQualification => 25;
}
