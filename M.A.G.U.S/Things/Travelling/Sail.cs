using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Travelling;

public class Sail : Thing
{
	public override Money Price => new(0, 2, 0);

    public override string Description => "A large sheet of canvas or heavy fabric rigged to a mast. Essential for harnessing the power of the wind to propel any large vessel across the water.";
}
