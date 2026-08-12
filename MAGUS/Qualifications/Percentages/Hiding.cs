using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Percentages;

public class Hiding(int percent) : PercentQualification(percent)
{
    public Hiding() : this(0) { }
}
