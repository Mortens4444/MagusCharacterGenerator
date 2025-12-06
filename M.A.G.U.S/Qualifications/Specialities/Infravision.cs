using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Specialities;

public class Infravision : SpecialQualification
{
    public int DistanceInMeters { get; }

    public Infravision(int distanceInMeters)
    {
        DistanceInMeters = distanceInMeters;
    }
}
