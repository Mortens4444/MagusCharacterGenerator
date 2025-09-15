using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Other;

public class NailDozens : Thing
{
	public override string Name => "Nail, dozens";

	public Money Price => new(0, 0, 1);
}
