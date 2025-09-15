using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Food;

public class RareSpice : Thing
{
	public override string Name => "Rare spice";

	public Money Price => new(0, 0, 7);
}
