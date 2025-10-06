using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class AbbitSteelFullPlate : Thing
{
	public override string Name => "Abbit-steel full plate";

	public override Money Price => new(500, 0, 0);

	public int MovementInhibitingFactor => -6;

	public int DamageSusceptiveValue => 7;

	public override double Weight => 15;
}
