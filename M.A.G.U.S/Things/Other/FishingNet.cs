using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Other;

public class FishingNet : Thing
{
	public override string Name => "Fishing net";

	public override Money Price => new(0, 0, 80);

    public override string Description => "A large, woven net used to sweep rivers or shallow seas to catch many fish at once. Requires skill and space to deploy effectively.";
}
