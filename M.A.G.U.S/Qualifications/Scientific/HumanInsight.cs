using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Scientific;

public class HumanInsight(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public override string Name => "Human insight";

    public override int QpToBaseQualification => 7;

    public override int QpToMasterQualification => 22;

    public HumanInsight() : this(QualificationLevel.Base) { }
}
