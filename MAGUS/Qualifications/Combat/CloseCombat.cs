using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Combat;

public class CloseCombat(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public override string Name => "Close combat";

    public override int QpToBaseQualification => 3;

    public override int QpToMasterQualification => 10;

    public CloseCombat() : this(QualificationLevel.Base) { }
}
