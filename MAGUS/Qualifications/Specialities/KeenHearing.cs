using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Specialities;

public class KeenHearing(double multiplier) : SpecialQualification
{
    public double Multiplier { get; } = multiplier;

    public override string Name => "Keen hearing";

    public override string ToString()
    {
        return $" ({Multiplier:F1}x)";
    }
}
