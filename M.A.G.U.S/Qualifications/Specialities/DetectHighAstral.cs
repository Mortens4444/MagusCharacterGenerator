using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Specialities;

public class DetectHighAstral(int distance) : SpecialQualification
{
    public int Distance { get; init; } = distance;

    public override string Name => "Detect high astral";
}
