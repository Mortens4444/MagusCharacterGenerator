namespace M.A.G.U.S.Qualifications.Percentages;

public class SenseOfDanger(int percent) : PercentQualification(percent)
{
    public override string Name => "A sense of danger";

    public SenseOfDanger() : this(0) { }
}
