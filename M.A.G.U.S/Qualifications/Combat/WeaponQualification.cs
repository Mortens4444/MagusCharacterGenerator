using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Things.Weapons;

namespace M.A.G.U.S.Qualifications.Combat;

public abstract class WeaponQualification : Qualification
{
    public WeaponQualification(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : base(qualificationLevel, level)
    {
    }

    public Weapon? Weapon { get; set; }
}
