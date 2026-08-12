using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Specialities;

public class DetectHighAstral(int distance) : SpecialQualification
{
    public int Distance { get; init; } = distance;

    public override string Name => "Detect high astral";
}
