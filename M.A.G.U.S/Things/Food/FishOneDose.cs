using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Food;

public class FishOneDose : Thing
{
	public override string Name => "Fish, one dose";

	public override Money Price => new(0, 0, 1);
}
