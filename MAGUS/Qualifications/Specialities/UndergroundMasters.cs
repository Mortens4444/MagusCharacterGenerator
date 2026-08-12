using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Specialities;

public class UndergroundMasters(int deviationInMeters) : SpecialQualification
{
    public int DeviationInMeters { get; } = deviationInMeters;

    public override string Name => "Masters of the underground";
}
