using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class MitrillLaminarArmor : Thing
{
	public override string Name => "Mitrill laminar armor";

	public override Money Price => new(4000, 0, 0);

	public int MovementInhibitingFactor => -1;

	public int DamageSusceptiveValue => 5;

	public int Weight => 5;
}
