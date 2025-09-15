using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Travelling;

public class PostChaiseForADay : Thing
{
	public override string Name => "Post chaise for a day";

	public Money Price => new(0, 0, 60);
}
