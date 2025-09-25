using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Specialities;

public class AdditionalLifePoints(byte extraLifePoints) : SpecialQualification
{
    public byte ExtraLifePoints { get; } = extraLifePoints;

    public override string Name => "Extra life points";
}
