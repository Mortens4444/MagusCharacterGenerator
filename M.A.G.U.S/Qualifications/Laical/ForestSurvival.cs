using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Laical;

public class ForestSurvival(QualificationLevel qualificationLevel = QualificationLevel.Base, byte level = 1) : Qualification(qualificationLevel, level)
{
    public override string Name => "Forest survival";

    public override byte QpToBaseQualification => 5;

    public override byte QpToMasterQualification => 14;
}
