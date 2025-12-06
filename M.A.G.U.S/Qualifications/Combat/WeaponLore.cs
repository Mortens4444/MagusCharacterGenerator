using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Combat;

public class WeaponLore(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public override string Name => "Weapon lore";

    public override int QpToBaseQualification => 10;

    public override int QpToMasterQualification => 20;
}
