using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Trappings;

public class Halter : Thing
{
	public override Money Price => new(0, 0, 3);

    public override string Description => "A simple head-stall of rope or leather placed around the beast's head, used primarily for leading or tethering it when not under the bit and bridle.";
}
