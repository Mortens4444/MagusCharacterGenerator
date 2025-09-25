using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Laical;

public class SexualCulture(QualificationLevel qualificationLevel = QualificationLevel.Base, byte level = 1) : Qualification(qualificationLevel, level)
{
    public override string Name => "Sexual culture";

    public override byte QpToBaseQualification => 5;

    public override byte QpToMasterQualification => 30;
}
