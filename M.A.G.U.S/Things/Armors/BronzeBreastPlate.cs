using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class BronzeBreastPlate : Thing
{
	public override string Name => "Bronze breastplate";

	public override Money Price => new(60, 0, 0);

	public int MovementInhibitingFactor => -4;

	public int DamageSusceptiveValue => 3;

	public override double Weight => 20;
}
