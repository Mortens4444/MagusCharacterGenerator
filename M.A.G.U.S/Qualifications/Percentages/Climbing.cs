using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Percentages;

public class Climbing(int percent) : PercentQualification(percent)
{
    public override string Name => "Climbing";

    public Climbing() : this(0) { }
}
