using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Animals;

public class Turkey : Thing
{
	public override string Name => "Turkey";

	public Money Price => new(0, 0, 8);
}
