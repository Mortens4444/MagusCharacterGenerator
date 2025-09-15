using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class SteelHalfPlate : Thing
{
	public override string Name => "Steel half plate";

	public Money Price => new(120, 0, 0);

	public int MovementInhibitingFactor => -6;

	public int DamageSusceptiveValue => 5;

	public int Weight => 30;
}
