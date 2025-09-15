using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Other;

public class FishingHook : Thing
{
	public override string Name => "Fishing hook";

	public Money Price => new(0, 0, 1);
}
