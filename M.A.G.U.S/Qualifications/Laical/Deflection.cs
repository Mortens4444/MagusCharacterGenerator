using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Laical;

public class Deflection(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public override string Name => "Deflection / evasive talk";

    public override int QpToBaseQualification => 3;

    public override int QpToMasterQualification => 9;
}
