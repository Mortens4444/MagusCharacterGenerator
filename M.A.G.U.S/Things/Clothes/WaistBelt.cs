using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Clothes;

public class WaistBelt : Thing
{
	public override string Name => "Waist belt";

	public Money Price => new(0, 0, 5);
}
