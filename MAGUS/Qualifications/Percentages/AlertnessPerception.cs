using MAGUS.GameSystem.Qualifications;

namespace MAGUS.Qualifications.Percentages;

public class AlertnessPerception(int percent) : PercentQualification(percent)
{
    public override string Name => "Alertness / perception";

    public AlertnessPerception() : this(0) { }
}
