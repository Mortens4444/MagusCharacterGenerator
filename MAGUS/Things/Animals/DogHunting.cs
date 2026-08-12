using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Animals;

public class DogHunting : Thing
{
	public override string Name => "Dog, hunting";

	public override Money Price => new(0, 2, 0);

    public override string Description => "A skilled hound, trained to track and corner game in the forest, whether deer or boar. Their superior scent and loyalty are highly valued by noble hunters.";
}
