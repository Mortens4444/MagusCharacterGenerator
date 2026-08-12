using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Combat;

public class HeavyArmorWearing(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1)
    : Qualification(qualificationLevel, level)
{
    public override string Name => "Heavy armor wearing";

    public override int QpToBaseQualification => 3;

    public override int QpToMasterQualification => 27;

    public HeavyArmorWearing() : this(QualificationLevel.Base) { }
}
