using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Other;

public class SealingWax : Thing
{
	public override string Name => "Sealing wax";

	public Money Price => new(0, 0, 10);
}
