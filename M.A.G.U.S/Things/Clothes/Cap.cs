using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Clothes;

public class Cap : Thing
{
	public override string Name => "Cap";

	public Money Price => new(0, 0, 5);
}
