using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Travelling;

public class CartWheel : Thing
{
	public override string Name => "Wagon wheel";

	public override Money Price => new(0, 0, 40);
}
