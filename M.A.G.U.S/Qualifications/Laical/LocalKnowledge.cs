using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Laical;

public class LocalKnowledge(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public override string Name => "Local knowledge";

    public override int QpToBaseQualification => 1;

    public override int QpToMasterQualification => 8;
}
