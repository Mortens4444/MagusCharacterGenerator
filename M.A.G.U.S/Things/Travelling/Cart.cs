using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Travelling;

public class Cart : Thing
{
	public override Money Price => new(0, 0, 150);
}
