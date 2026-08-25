using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Food;

public class Cheese : Thing
{
	public override Money Price => new(0, 0, 2);

    public override int HungerValue => 60;

    public override int PortionCount => 4;

    public override double Weight => 0.5;

    public override string Description => "A firm wedge of cured milk, its flavour varying greatly depending on its maker and age. A staple ration for travellers and an easy item to preserve.";
}
