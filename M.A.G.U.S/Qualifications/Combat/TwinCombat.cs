using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Combat;

public class TwinCombat(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public override string Name => "Twin combat";

    public override int QpToBaseQualification => 12;

    public override int QpToMasterQualification => 45;
}
