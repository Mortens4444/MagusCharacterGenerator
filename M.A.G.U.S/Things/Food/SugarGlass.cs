using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Food;

public class SugarGlass : Thing
{
	public override string Name => "Sugar, glass";

	public override Money Price => new(0, 0, 5);
}
