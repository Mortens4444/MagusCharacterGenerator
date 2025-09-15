using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Travelling;

public class GalleonPaddles : Thing
{
	public override string Name => "Galleon paddles";

	public Money Price => new(0, 3, 0);
}
