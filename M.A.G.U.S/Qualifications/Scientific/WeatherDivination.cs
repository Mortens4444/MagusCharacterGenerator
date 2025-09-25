using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Scientific;

public class WeatherDivination(QualificationLevel qualificationLevel = QualificationLevel.Base, byte level = 1) : Qualification(qualificationLevel, level)
{
    public override string Name => "Weather divination";

    public override byte QpToBaseQualification => 3;

    public override byte QpToMasterQualification => 15;
}
