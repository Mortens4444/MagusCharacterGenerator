using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Other;

public class ChainMeter : Thing
{
	public override string Name => "Chain, per meter";

	public override Money Price => new(0, 0, 5);

    public override string Description => "A length of interlocking iron links, typically one pace or meter long. Useful for securing heavy objects, shackling prisoners, or heavy rigging.";
}
