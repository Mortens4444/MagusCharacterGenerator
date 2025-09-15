using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Trappings;

public class SaddleBag : Thing
{
	public override string Name => "Saddle bag";

	public Money Price => new(0, 1, 0);
}
