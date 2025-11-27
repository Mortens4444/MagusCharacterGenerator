using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Food;

public class WineCup : Thing
{
	public override string Name => "Wine, cup";

	public override Money Price => new(0, 0, 1);

    public override string Description => "A simple cup filled with common, light wine. Cheaper and more ubiquitous than water in many cities, and a common accompaniment to any midday meal.";
}
