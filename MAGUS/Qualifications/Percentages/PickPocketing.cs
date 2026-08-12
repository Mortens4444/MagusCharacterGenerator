using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Percentages;

public class PickPocketing(int percent) : PercentQualification(percent)
{
    public override string Name => "Pick pocketing";

    public PickPocketing() : this(0) { }
}
