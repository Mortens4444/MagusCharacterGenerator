using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Food;

public class SaltBlock : Thing
{
	public override string Name => "Salt, block";

	public override Money Price => new(0, 0, 1);
}
