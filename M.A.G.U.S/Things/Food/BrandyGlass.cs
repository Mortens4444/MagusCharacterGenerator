using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Food;

public class BrandyGlass : Thing
{
	public override string Name => "Brandy, glass";

	public Money Price => new(0, 0, 2);
}
