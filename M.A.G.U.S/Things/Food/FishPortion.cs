using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Food;

public class FishPortion : Thing
{
	public override string Name => "Fish, portion";

	public override Money Price => new(0, 0, 1);
}
