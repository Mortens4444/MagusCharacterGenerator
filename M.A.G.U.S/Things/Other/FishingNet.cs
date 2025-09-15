using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Other;

public class FishingNet : Thing
{
	public override string Name => "Fishing net";

	public Money Price => new(0, 0, 80);
}
