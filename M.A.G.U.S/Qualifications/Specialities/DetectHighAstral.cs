using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Specialities;

public class DetectHighAstral : SpecialQualification
{
    public int Distance { get; init; }

    public DetectHighAstral(int distance)
    {
        Distance = distance;
    }

    public override string Name => "Detect high astral";
}
