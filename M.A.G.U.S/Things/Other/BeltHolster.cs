using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Other;

public class BeltHolster : Thing
{
	public override string Name => "Belt holster";

	public Money Price => new(0, 0, 70);
}
