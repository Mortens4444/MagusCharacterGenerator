using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Food;

public class FodderOneDay : Thing
{
	public override string Name => "Fodder, daily";

	public override Money Price => new(0, 0, 4);

    public override string Description => "A measure of hay, oats, and dried grain, sufficient to feed a single horse or draught animal for one full day. Essential for any journey.";
}
