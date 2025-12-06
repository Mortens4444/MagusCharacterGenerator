using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Combat;

public class HeavyArmorWearing(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1)
    : Qualification(qualificationLevel, level)
{
    public override string Name => "Heavy armor wearing";

    public override int QpToBaseQualification => 3;

    public override int QpToMasterQualification => 27;
}
