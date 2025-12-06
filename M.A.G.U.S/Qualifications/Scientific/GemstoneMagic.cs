using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Scientific;

public class GemstoneMagic(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public override string Name => "Gemstone magic";

    public override int QpToBaseQualification => 0;

    public override int QpToMasterQualification => 52;
}
