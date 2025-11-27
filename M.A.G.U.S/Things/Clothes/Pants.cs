using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Clothes;

public class Pants : Thing
{
	public override Money Price => new(0, 0, 20);

    public override string Description => "Basic leg coverings made of durable cloth or rough wool. Essential for common folk engaged in labour or simple travel.";
}
