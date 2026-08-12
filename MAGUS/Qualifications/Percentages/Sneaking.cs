using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Percentages;

public class Sneaking(int percent) : PercentQualification(percent)
{
    public Sneaking() : this(0) { }
}
