using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Combat;

public class UseOfParryingWeapon(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public override string Name => "Use of parrying weapon";

    public override int QpToBaseQualification => 3;

    public override int QpToMasterQualification => 10;

    public UseOfParryingWeapon() : this(QualificationLevel.Base) { }
}
