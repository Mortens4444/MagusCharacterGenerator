using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Food;

public class MeatOneDose : Thing
{
	public override string Name => "Meat, one dose";

	public Money Price => new(0, 0, 1);
}
