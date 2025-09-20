using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Other;

public class ChestSmall : Thing
{
	public override string Name => "Chest, small";

	public override Money Price => new(0, 3, 0);
}
