using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Food;

public class Loree : Thing
{
	public override Money Price => new(0, 0, 1);

    public override int HungerValue => 10;

    public override string Name => "Cheap wine";

    public override string Description => "A type of highly intoxicating, rare spirit or potent spiced wine, often associated with dark magic or secretive cults. Not a common drink, and best consumed with caution.";

    public override string[] Images => ["loree.png"];
}
