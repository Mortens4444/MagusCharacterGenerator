using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Travelling;

public class CartWheel : Thing
{
	public override string Name => "Wagon wheel";

	public override Money Price => new(0, 0, 40);

    public override string Description => "A single, robust wheel made of thick wood planks and often banded in iron. Essential for the function of any cart or wagon, and a frequent point of failure on the road.";
}
