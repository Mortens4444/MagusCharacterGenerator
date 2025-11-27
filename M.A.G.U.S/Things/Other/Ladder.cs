using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Other;

public class Ladder : Thing
{
	public override Money Price => new(0, 0, 25);

    public override string Description => "A simple frame of wood or rope with rungs, used for climbing to high places. Often cumbersome to carry but necessary for scaling walls or roofs.";
}
