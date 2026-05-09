using M.A.G.U.S.GameSystem.Qualifications;

namespace M.A.G.U.S.Qualifications.Percentages;

public class AlertnessPerception(int percent) : PercentQualification(percent)
{
    public override string Name => "Alertness / perception";

    public AlertnessPerception() : this(0) { }
}
