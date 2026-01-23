using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Laical;

public class ArticSurvival(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public override string Name => "Artic survival";

    public override int QpToBaseQualification => 5;

    public override int QpToMasterQualification => 14;

    public ArticSurvival() : this(QualificationLevel.Base) { }
}
