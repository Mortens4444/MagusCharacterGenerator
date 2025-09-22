using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Debauchery;

public class OrdinaryProstitute : Thing
{
	public override string Name => "Common prostitute";

	public override Money Price => new(0, 3, 0);
}
