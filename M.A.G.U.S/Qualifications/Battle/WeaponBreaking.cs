using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Battle;

public class WeaponBreaking(QualificationLevel qualificationLevel = QualificationLevel.Base, byte level = 1) : Qualification(qualificationLevel, level)
{
    public override string Name => "Weapon breaking";

    public override byte QpToBaseQualification => 5;

    public override byte QpToMasterQualification => 20;
}
