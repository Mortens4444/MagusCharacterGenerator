using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Percentages;

public class TightropeWalking(int percent) : PercentQualification(percent)
{
    public override string Name => "Tightrope walking";

    public TightropeWalking() : this(0) { }
}
