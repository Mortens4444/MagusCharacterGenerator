using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Other;

public class Rope20Meters : Thing
{
	public override string Name => "Rope (20 meters)";

	public override Money Price => new(0, 0, 30);

    public override string Description => "A long coil of thick, tightly woven hemp or flax cord, sufficient for climbing, tying, or securing large objects.";
}
