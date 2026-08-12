using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Food;

public class MilkJug : Thing
{
	public override string Name => "Milk, jug";

	public override Money Price => new(0, 0, 1);

    public override string Description => "A small pitcher of fresh cow or goat milk. A wholesome, refreshing drink, though it must be consumed quickly before it sours.";
}
