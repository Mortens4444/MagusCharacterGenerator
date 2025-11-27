using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Travelling;

public class PostChaiseForADay : Thing
{
	public override string Name => "Stagecoach, daily";

	public override Money Price => new(0, 0, 60);

    public override string Description => "A light, fast carriage hired specifically for a single day's urgent journey. Requires frequent changes of horses at post houses to maintain its high speed.";
}
