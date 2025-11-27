using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Other;

public class Whetstone : Thing
{
	public override Money Price => new(0, 0, 1);

    public override string Description => "A fine, smooth stone used with water or oil to sharpen blades, axes, and daggers, keeping them keen and effective.";
}
