using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Percentages;

public class Falling(int percent) : PercentQualification(percent)
{
    public Falling() : this(0) { }
}
