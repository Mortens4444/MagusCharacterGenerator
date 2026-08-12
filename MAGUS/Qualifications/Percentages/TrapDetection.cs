using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Percentages;

public class TrapDetection(int percent) : PercentQualification(percent)
{
    public override string Name => "Trap detection";

    public TrapDetection() : this(0) { }
}
