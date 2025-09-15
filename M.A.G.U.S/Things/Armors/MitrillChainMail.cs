using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class MitrillChainMail : Thing
{
	public override string Name => "Mitrill chain mail";

	public Money Price => new(1200, 0, 0);

	public int MovementInhibitingFactor => 0;

	public int DamageSusceptiveValue => 5;

	public int Weight => 10;
}
