using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Other;

public class OilForLamps : Thing
{
	public override string Name => "Oil for lamps";

	public Money Price => new(0, 0, 3);
}
