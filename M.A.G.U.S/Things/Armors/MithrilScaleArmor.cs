using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class MithrilScaleArmor : Thing
{
	public override string Name => "Mithril scale armor";

	public override Money Price => new(2000, 0, 0);

	public int MovementInhibitingFactor => 0;

	public int DamageSusceptiveValue => 5;

	public override double Weight => 5;
}
