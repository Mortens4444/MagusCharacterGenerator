using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Food;

public class MilkJug : Thing
{
	public override string Name => "Milk, jug";

	public override Money Price => new(0, 0, 1);
}
