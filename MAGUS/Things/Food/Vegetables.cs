using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Food;

public class Vegetables : Thing
{
	public override string Name => "Vegetables";

	public override Money Price => new(0, 0, 1);

    public override int HungerValue => 30;

    public override int PortionCount => 4;

    public override double Weight => 2.0;

    public override string Description => "A basket of common produce, such as cabbage, turnip, or carrots. A simple, fresh addition to the peasant's meal, usually bought by the season.";
}
