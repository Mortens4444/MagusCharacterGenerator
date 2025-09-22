using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class RingArmor : Thing
{
	public override string Name => "Ring mail";

	public override Money Price => new(2, 0, 0);

	public int MovementInhibitingFactor => -1;

	public int DamageSusceptiveValue => 1;

	public int Weight => 12;
}
