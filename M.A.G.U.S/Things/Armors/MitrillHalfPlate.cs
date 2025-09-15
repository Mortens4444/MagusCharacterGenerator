using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class MitrillHalfPlate : Thing
{
	public override string Name => "Mitrill half plate";

	public Money Price => new(12000, 0, 0);

	public int MovementInhibitingFactor => -3;

	public int DamageSusceptiveValue => 7;

	public int Weight => 8;
}
