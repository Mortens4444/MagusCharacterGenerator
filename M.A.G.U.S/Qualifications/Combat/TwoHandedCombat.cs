using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Combat;

public class TwoHandedCombat(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel,  level)
{
    public override string Name => "Two-handed combat";

    public override int QpToBaseQualification => 15;

    public override int QpToMasterQualification => 25;
}
