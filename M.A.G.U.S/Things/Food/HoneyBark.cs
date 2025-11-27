using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Food;

public class HoneyBark : Thing
{
	public override string Name => "Honey, jar";

	public override Money Price => new(0, 0, 4);

    public override string Description => "A thick slab of honeycomb or hardened wild honey. Used to sweeten food and drink, as refined sugar is a prohibitive luxury.";
}
