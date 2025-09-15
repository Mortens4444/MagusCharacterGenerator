using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Food;

public class LunchDinner : Thing
{
	public override string Name => "Lunch, dinner";

	public Money Price => new(0, 0, 5);
}
