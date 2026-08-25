using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Food;

public class HoneyJar : Thing
{
	public override string Name => "Honey, jar";

	public override Money Price => new(0, 0, 4);

    public override int HungerValue => 10;

    public override int PortionCount => 8;

    public override double Weight => 0.5;

    public override string Description => "A thick slab of honeycomb or hardened wild honey. Used to sweeten food and drink, as refined sugar is a prohibitive luxury.";
}
