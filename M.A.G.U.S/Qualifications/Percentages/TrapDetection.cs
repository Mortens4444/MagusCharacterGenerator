using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Percentages;

public class TrapDetection(int percent) : PercentQualification(percent)
{
    public override string Name => "Trap detection";

    public TrapDetection() : this(0) { }
}
