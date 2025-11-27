using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Food;

public class Cheese : Thing
{
	public override Money Price => new(0, 0, 2);

    public override string Description => "A firm wedge of cured milk, its flavour varying greatly depending on its maker and age. A staple ration for travellers and an easy item to preserve.";
}
