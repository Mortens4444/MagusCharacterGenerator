using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Food;

public class RareSpice : Thing
{
	public override string Name => "Rare spice";

	public override Money Price => new(0, 0, 7);

    public override string Description => "Exotic and costly flavourings like cloves, cinnamon, or ginger, imported from distant lands. Used to denote great wealth and to mask the taste of spoiled food.";
}
