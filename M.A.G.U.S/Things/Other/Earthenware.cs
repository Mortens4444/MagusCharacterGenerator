using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Other;

public class Earthenware : Thing
{
	public override Money Price => new(0, 0, 5);

    public override string Name => "Clay pot";
}
