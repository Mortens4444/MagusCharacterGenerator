using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class BronzeLaminarArmour : Thing
{
	public override string Name => "Bronze laminar armour";

	public override Money Price => new(30, 0, 0);

	public int MovementInhibitingFactor => -3;

	public int DamageSusceptiveValue => 2;

	public int Weight => 18;
}
