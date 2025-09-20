using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Other;

public class PaperSheet : Thing
{
	public override string Name => "Paper, sheet";

	public override Money Price => new(0, 0, 20);
}
