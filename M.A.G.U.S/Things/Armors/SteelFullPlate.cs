using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class SteelFullPlate : Thing
{
	public override string Name => "Steel full plate";

	public Money Price => new(200, 0, 0);

	public int MovementInhibitingFactor => -8;

	public int DamageSusceptiveValue => 6;

	public int Weight => 35;
}
