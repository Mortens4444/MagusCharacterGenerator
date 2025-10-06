using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class MithrilBreastplate : Thing
{
	public override string Name => "Mithril breastplate";

	public override Money Price => new(8000, 0, 0);

	public int MovementInhibitingFactor => -1;

	public int DamageSusceptiveValue => 6;

	public override double Weight => 6;
}
