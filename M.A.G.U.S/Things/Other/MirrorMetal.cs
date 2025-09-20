using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Other;

public class MirrorMetal : Thing
{
	public override string Name => "Metal mirror";

	public override Money Price => new(0, 0, 10);
}
