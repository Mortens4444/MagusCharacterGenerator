using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Specialities;

public class AdditionalLifePoints(int extraLifePoints) : SpecialQualification
{
    public int ExtraLifePoints { get; } = extraLifePoints;

    public override string Name => "Extra life points";

    public override string ToString()
    {
        return $" ({ExtraLifePoints})";
    }
}
