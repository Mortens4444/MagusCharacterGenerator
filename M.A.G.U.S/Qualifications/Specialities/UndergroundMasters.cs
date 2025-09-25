using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Specialities;

public class UndergroundMasters(byte deviationInMeters) : SpecialQualification
{
    public byte DeviationInMeters { get; } = deviationInMeters;

    public override string Name => "Masters of the underground";
}
