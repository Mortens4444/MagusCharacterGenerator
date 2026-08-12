using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Percentages;

public class Climbing(int percent) : PercentQualification(percent)
{
    public override string Name => "Climbing";

    public Climbing() : this(0) { }
}
