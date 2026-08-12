using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Percentages;

public class LockPicking(int percent) : PercentQualification(percent)
{
    public override string Name => "Lock picking";

    public LockPicking() : this(0) { }
}
