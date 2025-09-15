using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Clothes;

public class NobleShirt : Thing
{
	public override string Name => "Noble shirt";

	public Money Price => new(0, 2, 0);
}
