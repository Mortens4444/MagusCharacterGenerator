using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Percentages;

public class Falling(int percent) : PercentQualification(percent)
{
    public Falling() : this(0) { }
}
