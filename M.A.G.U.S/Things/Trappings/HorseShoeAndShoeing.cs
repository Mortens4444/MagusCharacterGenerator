using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Trappings;

public class HorseshoeAndShoeing : Thing
{
	public override string Name => "Horseshoe and shoeing";

	public override Money Price => new(0, 1, 0);

    public override string Description => "A set of curved iron plates nailed to the beast's hooves, along with the tools and service required for their proper fitting. Essential for protecting the hooves during long travel on hard roads.";
}
