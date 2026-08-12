using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Combat;

public class TwinCombat(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public override string Name => "Twin combat";

    public override int QpToBaseQualification => 12;

    public override int QpToMasterQualification => 45;

    public TwinCombat() : this(QualificationLevel.Base) { }
}
