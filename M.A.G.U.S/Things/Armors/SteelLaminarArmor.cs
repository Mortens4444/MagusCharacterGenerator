using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class SteelLaminarArmor : Thing
{
	public override string Name => "Steel laminar armor";

	public override Money Price => new(40, 0, 0);

	public int MovementInhibitingFactor => -3;

	public int DamageSusceptiveValue => 3;

	public int Weight => 16;
}
