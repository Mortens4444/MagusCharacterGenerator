using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Travelling;

public class BoatPaddles : Thing
{
	public override string Name => "Boat paddles";

	public Money Price => new(0, 1, 0);
}
