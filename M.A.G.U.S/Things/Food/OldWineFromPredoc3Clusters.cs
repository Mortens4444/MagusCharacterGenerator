using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Food;

public class OldWineFromPredoc3Clusters : Thing
{
	public override string Name => "Predoci vintage 3 cluster";

	public override Money Price => new(0, 1, 0);

    public override string Description => "A precious, older vintage from the celebrated Predoc vineyards, almost certainly reserved for the halls of Dukes and Kings, known for its deep, refined taste.";

    public override string[] Images => ["wine.png"];
}
