using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Other;

public class ChestLarge : Thing
{
	public override string Name => "Chest, large";

	public override Money Price => new(0, 6, 0);

    public override string Description => "A great, heavy wooden box bound with iron, often secured with a lock. Used for storing clothing, valuables, or important documents within a home or castle.";
}
