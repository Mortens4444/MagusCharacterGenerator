using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Interfaces;

namespace M.A.G.U.S.Qualifications.Combat;

public class WeaponUse(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level), ICanHaveMany
{
    public IWeapon? Weapon { get; set; }

    public override string Name => "Weapon use";

    public override int QpToBaseQualification => 3;

    public override int QpToMasterQualification => 30;
}
