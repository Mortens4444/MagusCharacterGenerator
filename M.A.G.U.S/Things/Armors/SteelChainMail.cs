using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class SteelChainMail : Thing
{
	public override string Name => "Steel chain mail";

	public override Money Price => new(12, 0, 0);

	public int MovementInhibitingFactor => -1;

	public int DamageSusceptiveValue => 3;

	public int Weight => 20;
}
