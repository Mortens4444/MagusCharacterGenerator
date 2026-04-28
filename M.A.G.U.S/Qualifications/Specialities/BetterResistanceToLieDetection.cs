using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Specialities;

public class BetterResistanceToLieDetection(int strength) : SpecialQualification
{
    public int Strength { get; } = strength;

    public override string Name => "Better resistance to lie detection";

    public override string ToString()
    {
        return $" ({Strength})";
    }
}
