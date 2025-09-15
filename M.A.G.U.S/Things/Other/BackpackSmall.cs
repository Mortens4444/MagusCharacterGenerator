using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Other;

public class BackpackSmall : Thing
{
	public override string Name => "Backpack, small";

	public Money Price => new(0, 0, 90);
}
