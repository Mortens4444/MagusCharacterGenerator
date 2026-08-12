using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Other;

public class Scales : Thing
{
	public override Money Price => new(0, 0, 45);

    public override string Description => "A portable balance with pans and weights, used by merchants and apothecaries to accurately measure quantities of goods or valuable substances.";
}
