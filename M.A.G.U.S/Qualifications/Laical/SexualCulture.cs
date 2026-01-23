using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Laical;

public class SexualCulture(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public override string Name => "Sexual culture";

    public override int QpToBaseQualification => 5;

    public override int QpToMasterQualification => 30;

    public SexualCulture() : this(QualificationLevel.Base) { }
}
