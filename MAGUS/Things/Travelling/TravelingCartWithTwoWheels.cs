using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Travelling;

public class TravelingCartWithTwoWheels : Thing
{
	public override string Name => "Traveling cart, two-wheeled";

	public override Money Price => new(5, 0, 0);

    public override string Description => "A robust, two-wheeled cart specifically built for long-distance travel and the harshness of the road, capable of carrying a family's goods.";
}
