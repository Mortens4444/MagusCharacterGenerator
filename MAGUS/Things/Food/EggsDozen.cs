using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Food;

public class EggsDozen : Thing
{
	public override string Name => "Eggs, dozen";

	public override Money Price => new(0, 0, 1);

    public override int HungerValue => 50;

    public override int PortionCount => 4;

    public override double Weight => 0.7;

    public override string Description => "A basket containing twelve eggs from chicken or ducks. A quick source of nourishment, easily bought from any village farmer.";
}
