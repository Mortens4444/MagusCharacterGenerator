using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Specialities;

public class DetectHighIntelligence : SpecialQualification
{
    public int Distance { get; init; }
    public DetectHighIntelligence(int distance)
    {
        Distance = distance;
    }

    public override string Name => "Detect high intelligence";
}
