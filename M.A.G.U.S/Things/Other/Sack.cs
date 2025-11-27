using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Other;

public class Sack : Thing
{
	public override Money Price => new(0, 0, 20);

    public override string Description => "A large, simple bag of woven cloth or burlap. Used to carry grain, dry goods, or any bulky item.";
}
