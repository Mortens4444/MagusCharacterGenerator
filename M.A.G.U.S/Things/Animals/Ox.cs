using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Animals;

public class Ox : Thing
{
	public override Money Price => new(0, 15, 0);

    public override string Description => "A castrated, powerful bull, chiefly used as a beast of burden for ploughing the heaviest soil or pulling heavy carts. Known for their sheer strength and slow, unrelenting pace.";
}
