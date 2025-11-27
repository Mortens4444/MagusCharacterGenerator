using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Other;

public class Basket : Thing
{
	public override Money Price => new(0, 0, 6);

    public override string Description => "A simple container woven from reeds or willow branches. Useful for gathering small produce, firewood, or carrying humble goods to market.";
}
