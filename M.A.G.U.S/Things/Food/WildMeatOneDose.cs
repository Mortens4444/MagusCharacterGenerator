using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Food;

public class WildMeatOneDose : Thing
{
	public override string Name => "Wild meat, one dose";

	public override Money Price => new(0, 0, 4);
}
