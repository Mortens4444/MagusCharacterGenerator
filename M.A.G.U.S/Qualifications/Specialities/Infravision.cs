using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Specialities;

public class Infravision : SpecialQualification
{
    public byte DistanceInMeters { get; }

    public Infravision(byte distanceInMeters)
    {
        DistanceInMeters = distanceInMeters;
    }
}
