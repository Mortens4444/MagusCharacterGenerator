using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Combat;

public class GroundCombat(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public override string Name => "Ground combat";

    public override int QpToBaseQualification => 5;

    public override int QpToMasterQualification => 12;

    public GroundCombat() : this(QualificationLevel.Base) { }
}
