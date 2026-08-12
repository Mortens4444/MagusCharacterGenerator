using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Specialities;

public class KeenSight(double multiplier) : SpecialQualification
{
    public double Multiplier { get; } = multiplier;

    public override string Name => "Keen sight";

    public override string ToString()
    {
        return $" ({Multiplier:F1}x)";
    }
}
