namespace M.A.G.U.S.Qualifications.Percentages;

public class PickPocketing(int percent) : PercentQualification(percent)
{
    public override string Name => "Pick pocketing";

    public PickPocketing() : this(0) { }
}
