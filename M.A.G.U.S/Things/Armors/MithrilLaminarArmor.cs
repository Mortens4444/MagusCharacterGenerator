using M.A.G.U.S.GameSystem.Valuables;

namespace M.A.G.U.S.Things.Armors;

public class MithrilLaminarArmor : Thing
{
	public override string Name => "Mithril plate armor";

	public override Money Price => new(4000, 0, 0);

	public int MovementInhibitingFactor => -1;

	public int DamageSusceptiveValue => 5;

	public int Weight => 5;
}
