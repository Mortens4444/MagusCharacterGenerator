using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Percentages;

public class FeenharFalconBetrayal(int percent) : PercentQualification(percent)
{
    public override string Name => "Feenhar's Falcon betrayal";

    public FeenharFalconBetrayal() : this(0) { }
}
