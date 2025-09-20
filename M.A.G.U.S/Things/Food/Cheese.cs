using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Food;

public class Cheese : Thing
{
	public override Money Price => new(0, 0, 2);
}
