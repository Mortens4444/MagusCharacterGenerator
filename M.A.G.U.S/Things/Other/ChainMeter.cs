using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Other;

public class ChainMeter : Thing
{
	public override string Name => "Chain, meter";

	public Money Price => new(0, 0, 5);
}
