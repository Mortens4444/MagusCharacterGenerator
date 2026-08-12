using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Combat;

public class TwoHandedCombat(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : WeaponQualification(qualificationLevel,  level)
{
    public override string Name => "Two-handed combat";

    public override int QpToBaseQualification => 15;

    public override int QpToMasterQualification => 25;

    public TwoHandedCombat() : this(QualificationLevel.Base) { }
}
