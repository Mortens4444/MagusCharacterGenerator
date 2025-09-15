using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class BronzeHalfPlate : Thing
{
	public override string Name => "Bronze half plate";

	public Money Price => new(100, 0, 0);

	public int MovementInhibitingFactor => -6;

	public int DamageSusceptiveValue => 4;

	public int Weight => 35;
}
