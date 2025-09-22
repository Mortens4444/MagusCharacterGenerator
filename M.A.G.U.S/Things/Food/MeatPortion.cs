using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Food;

public class MeatPortion : Thing
{
	public override string Name => "Meat, portion";

	public override Money Price => new(0, 0, 1);
}
