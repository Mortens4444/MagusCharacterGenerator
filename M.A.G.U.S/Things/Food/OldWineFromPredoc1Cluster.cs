using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Food;

public class OldWineFromPredoc1Cluster : Thing
{
	public override string Name => "Predoci vintage 1 cluster";

	public override Money Price => new(0, 0, 20);

    public override string Description => "A single bottle of aged, high-quality wine originating from the renowned Predoc region, noted for its complex bouquet. A true delight for the connoisseur.";
}
