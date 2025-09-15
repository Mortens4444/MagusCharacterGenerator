using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Food;

public class SpecialSpice : Thing
{
	public override string Name => "Special spice";

	public Money Price => new(0, 0, 20);
}
