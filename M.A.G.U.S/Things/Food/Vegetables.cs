using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Food;

public class Vegetables : Thing
{
	public override string Name => "Vegetables";

	public Money Price => new(0, 0, 1);
}
