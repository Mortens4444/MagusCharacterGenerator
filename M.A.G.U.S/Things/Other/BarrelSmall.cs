using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Other;

public class BarrelSmall : Thing
{
	public override string Name => "Barrel, small";

	public override Money Price => new(0, 2, 0);

    public override string Description => "A smaller wooden cask, easier to carry and used for preserving or transporting small amounts of precious drink or spirits.";
}
