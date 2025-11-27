using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Clothes;

public class Shoes : Thing
{
	public override Money Price => new(0, 1, 0);

    public override string Description => "Simple, low-cut leather footwear reaching to the ankle. Common for indoor wear or brief outings in dry weather.";
}
