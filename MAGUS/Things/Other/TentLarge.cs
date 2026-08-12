using MAGUS.GameSystem.Valuables;

namespace MAGUS.Things.Other;

public class TentLarge : Thing
{
	public override string Name => "Tent, large";

	public override Money Price => new(1, 0, 0);

    public override string Description => "A great canvas shelter capable of housing several men or serving as a common room for a large company during a campaign.";
}
