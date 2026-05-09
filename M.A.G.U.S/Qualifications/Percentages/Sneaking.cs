using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Percentages;

public class Sneaking(int percent) : PercentQualification(percent)
{
    public Sneaking() : this(0) { }
}
