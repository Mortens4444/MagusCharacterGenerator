using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Laical;

public class TrapSetting(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public override string Name => "Trap setting";

    public override int QpToBaseQualification => 10;

    public override int QpToMasterQualification => 20;
}
