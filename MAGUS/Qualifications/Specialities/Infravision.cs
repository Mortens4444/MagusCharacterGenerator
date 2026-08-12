using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Specialities;

public class Infravision : SpecialQualification
{
    public int DistanceInMeters { get; }

    public Infravision(int distanceInMeters)
    {
        DistanceInMeters = distanceInMeters;
    }
}
