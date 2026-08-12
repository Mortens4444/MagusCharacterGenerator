using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Specialities;

public sealed class MentalSight(int strength) : SpecialQualification
{
    public int Strength { get; } = strength;

    public override string Name => "Mental Sight";

    public override string ToString()
    {
        return $" ({Strength})";
    }
}