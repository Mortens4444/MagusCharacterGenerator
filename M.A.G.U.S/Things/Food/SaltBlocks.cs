using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Food;

public class SaltBlocks : Thing
{
	public override string Name => "Salt, blocks";

	public Money Price => new(0, 0, 1);
}
