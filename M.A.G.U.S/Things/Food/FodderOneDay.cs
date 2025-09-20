using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Food;

public class FodderOneDay : Thing
{
	public override string Name => "Fodder, one day";

	public override Money Price => new(0, 0, 4);
}
