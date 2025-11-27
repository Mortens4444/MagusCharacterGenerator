using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Trappings;

public class ChariotTools : Thing
{
	public override string Name => "Chariot tools";

	public override Money Price => new(0, 6, 0);

    public override string Description => "A collection of specialised tools and spare parts necessary for the immediate repair and maintenance of a war-chariot's wheels, axle, and frame on campaign.";
}
