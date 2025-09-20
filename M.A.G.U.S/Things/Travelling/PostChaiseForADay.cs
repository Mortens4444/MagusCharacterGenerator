using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Travelling;

public class PostChaiseForADay : Thing
{
	public override string Name => "Stagecoach, daily";

	public override Money Price => new(0, 0, 60);
}
