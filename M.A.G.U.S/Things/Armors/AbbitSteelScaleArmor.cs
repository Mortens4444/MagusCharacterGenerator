using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class AbbitSteelScaleArmor : Thing
{
	public override string Name => "Abbit-steel scale armor";

	public override Money Price => new(50, 0, 0);

	public int MovementInhibitingFactor => -1;

	public int DamageSusceptiveValue => 4;

	public override double Weight => 7;
}
