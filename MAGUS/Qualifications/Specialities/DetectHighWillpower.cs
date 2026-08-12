using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Specialities;

public class DetectHighWillpower : SpecialQualification
{
    public int Distance { get; init; }

    public DetectHighWillpower(int distance)
    {
        Distance = distance;
    }

    public override string Name => "Detect high willpower";
}
