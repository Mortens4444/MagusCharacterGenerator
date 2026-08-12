using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Clothes;

public class Pants : Thing
{
	public override Money Price => new(0, 0, 20);

    public override string Description => "Basic leg coverings made of durable cloth or rough wool. Essential for common folk engaged in labour or simple travel.";
}
