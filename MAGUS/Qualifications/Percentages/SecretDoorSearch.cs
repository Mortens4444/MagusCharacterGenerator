using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Percentages;

public class SecretDoorSearch(int percent) : PercentQualification(percent)
{
    public override string Name => "Secret door search";

    public SecretDoorSearch() : this(0) { }
}
