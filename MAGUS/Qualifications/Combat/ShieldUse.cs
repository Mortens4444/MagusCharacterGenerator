using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Combat;

public class ShieldUse(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1)
    : Qualification(qualificationLevel, level)
{
    public override string Name => "Shield use";

    public override int QpToBaseQualification => 5;

    public override int QpToMasterQualification => 30;

    public ShieldUse() : this(QualificationLevel.Base) { }
}
