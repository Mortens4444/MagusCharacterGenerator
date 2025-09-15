using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class SteelBreastPlate : Thing
{
	public override string Name => "Steel breast plate";

	public Money Price => new(80, 0, 0);

	public int MovementInhibitingFactor => -4;

	public int DamageSusceptiveValue => 4;

	public int Weight => 18;
}
