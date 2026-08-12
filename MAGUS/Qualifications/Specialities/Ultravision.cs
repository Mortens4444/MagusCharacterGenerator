using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Specialities;

public class Ultravision(int distanceInMeters) : SpecialQualification
{
    public int DistanceInMeters { get; } = distanceInMeters;
}
