using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Food;

public class CommonSpice : Thing
{
	public override string Name => "Common spice";

	public override Money Price => new(0, 0, 2);

    public override string Description => "Everyday flavourings such as onion, garlic, or dried herbs. Used to make plain food palatable and can be found in most town markets.";
}
