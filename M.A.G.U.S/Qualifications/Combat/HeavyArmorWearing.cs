using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Combat;

public class HeavyArmorWearing(QualificationLevel qualificationLevel = QualificationLevel.Base, byte level = 1)
    : Qualification(qualificationLevel, level)
{
    public override string Name => "Heavy armor wearing";

    public override byte QpToBaseQualification => 3;

    public override byte QpToMasterQualification => 27;
}
