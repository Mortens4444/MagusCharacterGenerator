using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Food;

public class LunchDinner : Thing
{
	public override string Name => "Lunch, dinner";

	public override Money Price => new(0, 0, 5);

    public override string Description => "A single, prepared meal, served hot at an inn or tavern. Typically consists of stew, bread, and perhaps a small cut of common meat.";

    public override string[] Images => ["lunch_dinner.png"];
}
