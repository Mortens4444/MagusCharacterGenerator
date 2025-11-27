using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Food;

public class BrandyGlass : Thing
{
	public override string Name => "Brandy, bottle";

	public override Money Price => new(0, 0, 2);

    public override string Description => "A small, fine glass holding a portion of strong, distilled wine. Reserved for noble tables or for curing severe chills, as it carries a high cost and a potent effect.";
}
