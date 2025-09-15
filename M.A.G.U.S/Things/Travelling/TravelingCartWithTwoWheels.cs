using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Travelling;

public class TravelingCartWithTwoWheels : Thing
{
	public override string Name => "Traveling cart with two wheels";

	public Money Price => new(5, 0, 0);
}
