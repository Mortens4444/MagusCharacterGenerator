using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Percentages;

public class TightropeWalking(int percent) : PercentQualification(percent)
{
    public override string Name => "Tightrope walking";

    public TightropeWalking() : this(0) { }
}
