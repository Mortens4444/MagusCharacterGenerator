using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class MithrilHalfPlate : Thing
{
	public override string Name => "Mithril half plate";

	public override Money Price => new(12000, 0, 0);

	public int MovementInhibitingFactor => -3;

	public int DamageSusceptiveValue => 7;

	public override double Weight => 8;
}
