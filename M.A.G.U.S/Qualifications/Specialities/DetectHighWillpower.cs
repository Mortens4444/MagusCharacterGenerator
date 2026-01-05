using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Specialities;

public class DetectHighWillpower : SpecialQualification
{
    public int Distance { get; init; }

    public DetectHighWillpower(int distance)
    {
        Distance = distance;
    }

    public override string Name => "Detect high willpower";
}
