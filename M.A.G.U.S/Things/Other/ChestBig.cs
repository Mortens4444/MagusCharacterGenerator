using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Other;

public class ChestBig : Thing
{
	public override string Name => "Chest, big";

	public Money Price => new(0, 6, 0);
}
