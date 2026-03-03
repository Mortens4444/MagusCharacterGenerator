using M.A.G.U.S.GameSystem.Qualifications;
using M.A.G.U.S.Things.Clothes;

namespace M.A.G.U.S.Qualifications.Specialities;

public sealed class AstralSight(int strength) : SpecialQualification
{
    public int Strength { get; } = strength;

    public override string Name => "Astral Sight";

    public override string ToString()
    {
        return $" ({Strength})";
    }
}