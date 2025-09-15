using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Other;

public class BarrelSmall : Thing
{
	public override string Name => "Barrel, small";

	public Money Price => new(0, 2, 0);
}
