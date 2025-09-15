using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class HardenedLeatherArmor : Thing
{
	public override string Name => "Hardened leather armor";

	public Money Price => new(0, 5, 0);

	public int MovementInhibitingFactor => -2;

	public int DamageSusceptiveValue => 2;

	public int Weight => 7;
}
