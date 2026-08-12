using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Percentages;

public class Divination(int percent) : PercentQualification(percent)
{
    public Divination() : this(0) { }
}
