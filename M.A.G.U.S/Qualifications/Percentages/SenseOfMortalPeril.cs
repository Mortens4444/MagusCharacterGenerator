namespace M.A.G.U.S.Qualifications.Percentages;

public class SenseOfMortalPeril(int percent) : PercentQualification(percent)
{
    public override string Name => "A sense of mortal peril";

    public SenseOfMortalPeril() : this(0) { }
}
