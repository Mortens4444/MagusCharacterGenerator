using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Clothes;

public class CapeFabric : Thing
{
	public override string Name => "Cloak, cloth";

	public override Money Price => new(0, 1, 0);

    public override string Description => "A practical cloak made of thick, woven wool or canvas. It shields the wearer from rain, wind, and the eyes of strangers.";
}
