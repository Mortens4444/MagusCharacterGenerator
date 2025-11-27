using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Food;

public class OldWineFromPredoc2Clusters : Thing
{
	public override string Name => "Predoci vintage 2 cluster";

	public override Money Price => new(0, 0, 50);

    public override string Description => "A bottle of exceptionally well-aged wine from Predoc. The difference in vintage grants it greater character and depth, highly valued by the wealthy.";
}
