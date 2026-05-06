using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Laical;

public class DesertSurvival(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level), ILaicalQualification
{
    public override string Name => "Desert survival";

    public override int QpToBaseQualification => 5;

    public override int QpToMasterQualification => 14;

    public DesertSurvival() : this(QualificationLevel.Base) { }
}
