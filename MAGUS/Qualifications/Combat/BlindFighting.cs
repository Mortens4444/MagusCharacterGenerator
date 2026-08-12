using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Combat;

public class BlindFighting(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public override string Name => "Blind fighting";

    public override int QpToBaseQualification => 10;

    public override int QpToMasterQualification => 30;

    public BlindFighting() : this(QualificationLevel.Base) { }
}
