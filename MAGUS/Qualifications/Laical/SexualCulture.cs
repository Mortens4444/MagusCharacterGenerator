using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Laical;

public class SexualCulture(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level), ILaicalQualification
{
    public override string Name => "Sexual culture";

    public override int QpToBaseQualification => 5;

    public override int QpToMasterQualification => 30;

    public SexualCulture() : this(QualificationLevel.Base) { }
}
