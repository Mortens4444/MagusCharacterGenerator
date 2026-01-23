using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Laical;

public class SwampSurvival(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public override string Name => "Swamp survival";

    public override int QpToBaseQualification => 5;

    public override int QpToMasterQualification => 14;

    public SwampSurvival() : this(QualificationLevel.Base) { }
}
