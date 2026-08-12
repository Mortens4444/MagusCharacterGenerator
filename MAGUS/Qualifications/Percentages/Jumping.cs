using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Percentages;

public class Jumping(int percent) : PercentQualification(percent)
{
    public Jumping() : this(0) { }
}
