using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Other;

public class NailDozen : Thing
{
	public override string Name => "Nail, dozen";

	public override Money Price => new(0, 0, 1);

    public override string Description => "A set of twelve iron spikes of various sizes. Necessary for any kind of construction or quick repair of wooden objects.";
}
