using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Other;

public class Hammer : Thing
{
	public override Money Price => new(0, 0, 10);

    public override string Description => "A simple tool with a wooden handle and iron head. Used for driving nails, shaping metal, or general construction and repair.";
}
