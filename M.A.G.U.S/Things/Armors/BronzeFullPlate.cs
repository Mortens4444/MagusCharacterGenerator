using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class BronzeFullPlate : Thing
{
	public override string Name => "Bronze full plate";

	public Money Price => new(160, 0, 0);

	public int MovementInhibitingFactor => -8;

	public int DamageSusceptiveValue => 5;

	public int Weight => 40;
}
