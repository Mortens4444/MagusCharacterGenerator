using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Trappings;

public class PackSaddle : Thing
{
	public override string Name => "Saddle, pack";

	public override Money Price => new(0, 2, 0);

    public override string Description => "A stout, unadorned saddle designed not for riding but for securing great loads and bundles upon the back of a mule or horse. It distributes weight to prevent injury to the animal.";
}
