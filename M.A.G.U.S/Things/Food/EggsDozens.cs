using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Food;

public class EggsDozens : Thing
{
	public override string Name => "Eggs, dozens";

	public Money Price => new(0, 0, 1);
}
