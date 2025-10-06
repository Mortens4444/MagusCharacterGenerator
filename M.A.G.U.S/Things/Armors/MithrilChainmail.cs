using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class MithrilChainmail : Thing
{
	public override string Name => "Mithril chainmail";

	public override Money Price => new(1200, 0, 0);

	public int MovementInhibitingFactor => 0;

	public int DamageSusceptiveValue => 5;

	public override double Weight => 10;
}
