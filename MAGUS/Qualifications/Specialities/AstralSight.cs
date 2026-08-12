using MAGUS.GameSystem.Qualifications;
using MAGUS.Things.Clothes;

namespace MAGUS.Qualifications.Specialities;

public sealed class AstralSight(int strength) : SpecialQualification
{
    public int Strength { get; } = strength;

    public override string Name => "Astral Sight";

    public override string ToString()
    {
        return $" ({Strength})";
    }
}