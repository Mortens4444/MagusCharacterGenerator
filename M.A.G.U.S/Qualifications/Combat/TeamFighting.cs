using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Combat;

public class TeamFighting(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public override string Name => "Team fighting";

    public override int QpToBaseQualification => 7;

    public override int QpToMasterQualification => 30;

    public TeamFighting() : this(QualificationLevel.Base) { }
}
