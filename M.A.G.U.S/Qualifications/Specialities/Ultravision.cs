using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Specialities;

public class Ultravision(byte distanceInMeters) : SpecialQualification
{
    public byte DistanceInMeters { get; } = distanceInMeters;
}
