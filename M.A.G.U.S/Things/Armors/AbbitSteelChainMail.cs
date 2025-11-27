using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class AbbitSteelChainMail : Thing
{
	public override string Name => "Abbit-steel chainmail";

	public override Money Price => new(30, 0, 0);

	public int MovementInhibitingFactor => 0;

	public int DamageSusceptiveValue => 4;

	public override double Weight => 12;

    public override string Description => "A shirt of interlocking rings fashioned from the rare and potent Abbit-steel. It is lighter than plate yet resists slashes and piercing thrusts with exceptional resilience.";
}
