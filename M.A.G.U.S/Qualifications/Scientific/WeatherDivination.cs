using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Scientific;

public class WeatherDivination(QualificationLevel qualificationLevel = QualificationLevel.Base, int level = 1) : Qualification(qualificationLevel, level)
{
    public override string Name => "Weather divination";

    public override int QpToBaseQualification => 3;

    public override int QpToMasterQualification => 15;

    public WeatherDivination() : this(QualificationLevel.Base) { }
}
