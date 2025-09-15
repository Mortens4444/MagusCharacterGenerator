using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Clothes;

public class Caftan : Thing
{
	public override string Name => "Caftan";

	public Money Price => new(0, 5, 0);
}
