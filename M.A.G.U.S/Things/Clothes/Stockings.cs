using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Clothes;

public class Stockings : Thing
{
	public override Money Price => new(0, 0, 6);

    public override string Description => "Long, close-fitting hose worn on the legs, typically secured to the belt. Essential for warmth and modesty beneath breeches or robes.";
}
