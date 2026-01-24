using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Debauchery;

public class MaleProstitute : Thing
{
	public override string Name => "Male prostitute";

	public override Money Price => new(0, 5, 0);

    public override string Description => "A male prostitute, one who sold his body for coin, often serving noblewomen, widows, or wealthy patrons. Such men lived on the margins of society and were commonly regarded with suspicion and moral disdain.";
}
