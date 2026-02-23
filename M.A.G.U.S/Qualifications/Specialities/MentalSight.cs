using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Specialities;

public sealed class MentalSight(int strength) : SpecialQualification
{
    public int Strength { get; } = strength;

    public override string Name => "Mental Sight";
}