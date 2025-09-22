using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Clothes;

public class PeasantShirt : Thing
{
	public override string Name => "Peasant shirt";

	public override Money Price => new(0, 0, 5);
}
