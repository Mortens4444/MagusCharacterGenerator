using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Other;

public class FlintAndSteel : Thing
{
	public override string Name => "Flint and steel";

	public Money Price => new(0, 0, 5);
}
