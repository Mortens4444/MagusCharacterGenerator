using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Percentages;

public class SenseOfMortalPeril(int percent) : PercentQualification(percent)
{
    public override string Name => "A sense of mortal peril";

    public SenseOfMortalPeril() : this(0) { }
}
