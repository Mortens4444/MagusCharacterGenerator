using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Percentages;

public class FeenharFalconBetrayal(int percent) : PercentQualification(percent)
{
    public override string Name => "Feenhar's Falcon betrayal";

    public FeenharFalconBetrayal() : this(0) { }
}
