using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Percentages;

public class TrackingEvasion(int percent) : PercentQualification(percent)
{
    public override string Name => "Tracking / evasion";

    public TrackingEvasion() : this(0) { }
}
