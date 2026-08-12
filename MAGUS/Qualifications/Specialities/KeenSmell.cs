using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Specialities;

public class KeenSmell(double multiplier) : SpecialQualification
{
    public double Multiplier { get; } = multiplier;

    public override string Name => "Keen smell";
    
    public override string ToString()
    {
        return $" ({Multiplier:F1}x)";
    }
}
