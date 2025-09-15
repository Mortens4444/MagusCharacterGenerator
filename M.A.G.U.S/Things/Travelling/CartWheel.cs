using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Travelling;

public class CartWheel : Thing
{
	public override string Name => "Cart wheel";

	public Money Price => new(0, 0, 40);
}
