using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class MitrillScaleArmor : Thing
{
	public override string Name => "Mitrill scale armor";

	public Money Price => new(2000, 0, 0);

	public int MovementInhibitingFactor => 0;

	public int DamageSusceptiveValue => 5;

	public int Weight => 5;
}
