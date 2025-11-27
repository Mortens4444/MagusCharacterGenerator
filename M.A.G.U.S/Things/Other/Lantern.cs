using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Other;

public class Lantern : Thing
{
	public override Money Price => new(0, 0, 10);

    public override string Description => "A covered metal casing with horn or glass panels and an internal lamp or candle. It directs light and is essential for navigating dark tunnels or night roads.";
}
