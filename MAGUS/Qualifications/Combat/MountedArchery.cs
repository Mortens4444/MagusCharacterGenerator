using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Combat;

public class MountedArchery(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1)
    : Qualification(qualificationLevel, level)
{
    public override string Name => "Mounted archery";

    public override int QpToBaseQualification => 15;

    public override int QpToMasterQualification => 30;

    public MountedArchery() : this(QualificationLevel.Base) { }
}
