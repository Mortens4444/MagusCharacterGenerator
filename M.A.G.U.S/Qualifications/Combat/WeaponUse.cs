using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Combat;

public class WeaponUse(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1)
    : WeaponQualification(qualificationLevel, level), ICanHaveMany
{
    public override string Name => "Weapon use";

    public override int QpToBaseQualification => 3;

    public override int QpToMasterQualification => 30;

    public override string ToString()
    {
        if (Weapon == null)
        {
            return Name;
        }
        return $"{Name} - {Weapon}";
    }
}
