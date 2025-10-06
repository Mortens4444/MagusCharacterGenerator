using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class MithrilFullPlate : Thing
{
	public override string Name => "Mithril full plate";

	public override Money Price => new(20000, 0, 0);

	public int MovementInhibitingFactor => -4;

	public int DamageSusceptiveValue => 8;

	public override double Weight => 10;
}
