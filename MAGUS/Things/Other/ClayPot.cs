using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Other;

public class ClayPot : Thing
{
	public override Money Price => new(0, 0, 5);

    public override string Name => "Clay pot";

    public override string Description => "Common pottery, such as bowls, pitchers, and plates, baked from clay. It is fragile but affordable for holding food and drink.";
}
