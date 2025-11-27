using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Food;

public class OldWineFromPredoc5Clusters : Thing
{
	public override string Name => "Predoci vintage 5 cluster";

	public override Money Price => new(5, 0, 0);

    public override string Description => "The finest and most ancient wine of Predoc, virtually unattainable and said to bestow great wisdom or fortune upon the drinker. A true treasure.";
}
