using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Trappings;

public class ReinsBridleSnaffle : Thing
{
	public override string Name => "Reins, bridle, bit";

	public override Money Price => new(0, 0, 15);

    public override string Description => "The complete head-harness for guiding a horse. Includes the bridle with cheekpieces and crownpiece, the reins for control, and a simple snaffle bit that sits gently in the beast's mouth.";
}
