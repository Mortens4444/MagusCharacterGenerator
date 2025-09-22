using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class AbbitSteelHalfPlate : Thing
{
	public override string Name => "Abbit-steel half plate";

	public override Money Price => new(300, 0, 0);

	public int MovementInhibitingFactor => -4;

	public int DamageSusceptiveValue => 6;

	public int Weight => 12;
}
