using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Combat;

public class WeaponBreaking(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public override string Name => "Weapon breaking";

    public override int QpToBaseQualification => 5;

    public override int QpToMasterQualification => 20;
}
