using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Laical;

public class HuntingAndFishing(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public override string Name => "Hunting/fishing";

    public override int QpToBaseQualification => 8;

    public override int QpToMasterQualification => 15;
}
