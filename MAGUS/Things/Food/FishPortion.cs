using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Food;

public class FishPortion : Thing
{
	public override string Name => "Fish, portion";

	public override Money Price => new(0, 0, 1);

    public override int HungerValue => 80;

    public override string Description => "A single serving of fresh or salted fish, perhaps from river or sea. A necessary meal for those who live near water or who observe the Church's meatless days.";
}
