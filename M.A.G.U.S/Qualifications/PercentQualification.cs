namespace M.A.G.U.S.Qualifications;

public class PercentQualification(byte percent)
{
    public byte Percent { get; set; } = percent;

    public virtual string Name => GetType().Name;

    public string ToFullString()
	{
		return String.Concat(ToString(), $" {Percent}%");
	}
}
