using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Scientific;

public class RuneMagic(QualificationLevel qualificationLevel = QualificationLevel.Base, byte level = 1) : Qualification(qualificationLevel, level)
{
    public override string Name => "Rune magic";

    public override byte QpToBaseQualification => 18;

    public override byte QpToMasterQualification => 45;
}
