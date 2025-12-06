using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Scientific;

public class RunicMagic(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public override string Name => "Runic magic";

    public override int QpToBaseQualification => 18;

    public override int QpToMasterQualification => 45;
}
