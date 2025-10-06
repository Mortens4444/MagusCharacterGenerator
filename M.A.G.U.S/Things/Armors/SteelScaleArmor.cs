using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class SteelScaleArmor : Thing
{
	public override string Name => "Steel scale armor";

	public override Money Price => new(20, 0, 0);

	public int MovementInhibitingFactor => -2;

	public int DamageSusceptiveValue => 3;

	public override double Weight => 16;
}
