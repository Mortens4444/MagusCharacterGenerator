using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Specialities;

public class SurvivalWithoutFood(double days) : SpecialQualification
{
    public double Days { get; } = days;

    public override string Name => "Survival without food";

    public override string ToString()
    {
        return $" ({Days:F1})";
    }
}
