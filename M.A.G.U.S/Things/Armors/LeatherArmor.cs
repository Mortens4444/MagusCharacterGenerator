using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class LeatherArmor : Thing
{
	public override string Name => "Studded leather";

	public override Money Price => new(0, 4, 0);

	public int MovementInhibitingFactor => 0;

	public int DamageSusceptiveValue => 1;

	public override double Weight => 8;
}
