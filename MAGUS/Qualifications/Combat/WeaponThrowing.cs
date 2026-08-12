using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Combat;

public class WeaponThrowing(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1)
    : WeaponQualification(qualificationLevel, level), ICanHaveMany
{
    public override string Name => "Weapon throwing";

    public override int QpToBaseQualification => 4;

    public override int QpToMasterQualification => 40;

    public override string ToString()
    {
        if (Weapon == null)
        {
            return Name;
        }
        return $"{Name} - {Weapon}";
    }

    public WeaponThrowing() : this(QualificationLevel.Base) { }
}
