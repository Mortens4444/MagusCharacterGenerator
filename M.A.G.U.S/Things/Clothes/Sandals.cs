using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Clothes;

public class Sandals : Thing
{
	public override Money Price => new(0, 0, 4);

    public override string Description => "Open footwear consisting of little more than a sole secured by straps. Suitable only for the hottest, dry weather and offering minimal defense to the foot.";
}
