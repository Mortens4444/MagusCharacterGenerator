using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Specialities;

public class SurvivalWithoutFood(double days) : SpecialQualification
{
    public double Days { get; } = days;

    public override string Name => "Survival without food";

    public override string ToString()
    {
        return $" ({Days:F1})";
    }
}
