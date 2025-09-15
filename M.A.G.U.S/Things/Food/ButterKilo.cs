using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Food;

public class ButterKilo : Thing
{
	public override string Name => "Butter, kilo";

	public Money Price => new(0, 0, 2);
}
