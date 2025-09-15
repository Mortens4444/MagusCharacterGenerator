using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class AbbitSteelChainMail : Thing
{
	public override string Name => "Abbit steel chain mail";

	public Money Price => new(30, 0, 0);

	public int MovementInhibitingFactor => 0;

	public int DamageSusceptiveValue => 4;

	public int Weight => 12;
}
