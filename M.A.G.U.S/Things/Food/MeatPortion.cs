using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Food;

public class MeatPortion : Thing
{
	public override string Name => "Meat, portion";

	public override Money Price => new(0, 0, 1);

    public override string Description => "A serving of common meat, usually pork, beef, or mutton. Sufficient to fill a single man for a day, often served stewed or roasted.";
}
